using ManualDoCoroinha.DTOs;
using ManualDoCoroinha.DTOs.Users;
using ManualDoCoroinha.Models.Users;
using ManualDoCoroinha.Repositories;
using ManualDoCoroinha.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ManualDoCoroinha.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class AuthController : ApiController
{
    private readonly ITokenService _tokenService;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole<Guid>> _roleManager;
    private readonly IConfiguration _config;
    private readonly IUnitOfWorks _uof;

    public AuthController(ITokenService tokenService,
                          UserManager<User> userManager,
                          RoleManager<IdentityRole<Guid>> roleManager,
                          IConfiguration config,
                          IUnitOfWorks uof)
    {
        _tokenService = tokenService;
        _userManager = userManager;
        _roleManager = roleManager;
        _config = config;
        _uof = uof;
    }

    [HttpPost]
    [Route("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);

        if (user is not null && await _userManager.CheckPasswordAsync(user, model.Password!))
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            var authClains = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName!),
                new Claim(ClaimTypes.Email, user.Email!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            foreach (var userRole in userRoles)
            {
                authClains.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var token = _tokenService.GenerateAccessToken(authClains, _config);

            var refreshToken = _tokenService.GenerateRefreshToken();

            _ = int.TryParse(_config["JWT:RefreshTokenValidityInMinutes"], out int refreshTokenValidityImMinutes);

            user.RefreshToken = refreshToken;

            user.RefreshTokenExpiryTime = DateTime.Now.AddMinutes(refreshTokenValidityImMinutes);

            await _userManager.UpdateAsync(user);

            var tokenData = new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                UserName = user.UserName,
                Email = user.Email,
                IsAdmin = user.IsAdmin,
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };

            return Ok(new { success = true, data = tokenData});
        }
        return BadRequest(new { success = false, Message = "Email ou senha inválidos" });
    }

    [HttpPost]
    [Route("register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var userByEmail = await _userManager.FindByEmailAsync(model.Email);

        if (userByEmail is not null)
            return BadRequest(new { success = false, message = "E-mail já cadastrado." });

        var userByUserName = await _userManager.FindByNameAsync(model.Username);

        if (userByUserName is not null)
            return BadRequest(new { success = false, message = "Nome de usuário já está em uso." });

        var user = new User
        {
            Name = model.Name,
            UserName = model.Username,
            Email = model.Email,
            Birthday = model.Birthday,
            IsAdmin = false,
            LastLogin = null
        };

        var result = await _userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded)
            return BadRequest(new { success = false, errors = result.Errors.Select(e => e.Description) });

        return Ok(new { success = true, message = "Usuário criado com sucesso." });
    }

    [AllowAnonymous]
    [HttpGet("validate-username/{username}")]
    public async Task<ActionResult<bool>> ValidateUsername(string username)
    {
        if (string.IsNullOrEmpty(username))
            return BadRequest( new { success = false, message = "Erro ao tentar validar o username" });

        var user = await _uof.UserRepository.Get(u => u.UserName == username);

        if (user != null)
            return Ok( new { success = true, data = false } );

        return Ok( new { success = true, data = true });
    }

    [HttpPost]
    [Route("refresh-token")]
    public async Task<IActionResult> RefreshToken([FromBody] TokenModel tokenModel)
    {
        if (tokenModel is null)
            return BadRequest(new { success = false, message = "Token inválido." });

        string? accessToken = tokenModel.AccessToken ?? throw new ArgumentNullException(nameof(tokenModel));

        string? refreshToken = tokenModel.RefreshToken ?? throw new ArgumentNullException(nameof(tokenModel));

        var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken!, _config);

        if(principal == null)
            return BadRequest(new { success = false, message = "Token inválido." });

        string username = principal.Identity.Name;

        var user = await _userManager.FindByNameAsync(username!);

        if(user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
            return BadRequest(new { success = false, message = "Token inválido." });

        var newAccessToken = _tokenService.GenerateAccessToken(principal.Claims.ToList(), _config);

        var newRefreshToken = _tokenService.GenerateRefreshToken();

        user.RefreshToken = newRefreshToken;
        await _userManager.UpdateAsync(user);

        var tokenData = new
        {
            Token = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
            RefreshToken = newRefreshToken,
            Expiration = newAccessToken.ValidTo
        };

        return Ok(new { success = true, data = tokenData });
    }

    [HttpPost]
    [Route("revoke/{username}")]
    public async Task<IActionResult> Revoke(string username)
    {
        var user = await _userManager.FindByNameAsync(username);

        if (user == null)
            return NotFound(new { success = false, message = "Usuário não encontrado." });

        user.RefreshToken = null;

        await _userManager.UpdateAsync(user);

        return Ok(new { success = true, message = "Refresh token revogado com sucesso." });
    }
}