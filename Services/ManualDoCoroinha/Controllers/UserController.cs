using AutoMapper;
using ManualDoCoroinha.Shared.DTOs.Users;
using ManualDoCoroinha.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ManualDoCoroinha.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class UserController : ApiController
{
    private readonly IUnitOfWorks _uof;
    private readonly IMapper _mapper;

    public UserController(IUnitOfWorks uof, IMapper mapper)
    {
        _uof = uof;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("my-profile")]
    public async Task<ActionResult<UserDto>> GetMyProfile()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if(!Guid.TryParse(userId, out var userGuid))
            return Unauthorized(new {success = false, Message = "Usuário não autorizado"});

        var user = await _uof.UserRepository.Get(p => p.Id == userGuid);

        if (user == null)
            return BadRequest(new {success = false, message = "Nenhum usuário encontrado"});

        var userDto = _mapper.Map<UserDto>(user);

        return Ok(new { success = true, data = userDto});
    }
}
