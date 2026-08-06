using AutoMapper;
using ManualDoCoroinha.DTOs.UserFavoritePrayers;
using ManualDoCoroinha.Models.UserFavoritePrayers;
using ManualDoCoroinha.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ManualDoCoroinha.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class UserFavoritePrayerController : ApiController
{
    private readonly IUnitOfWorks _uof;
    private readonly IMapper _mapper;

    public UserFavoritePrayerController(IUnitOfWorks uof, IMapper mapper)
    {
        _uof = uof;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> AddFavoritePrayer(CreateUserFavoritePrayerDto dto)
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (!Guid.TryParse(userIdClaim, out var userId))
            return Unauthorized(new { success = false, message = "Usuário não autorizado" });

        if (dto is null)
            return BadRequest(new { success = false, data = "Objeto vazio" });

        var prayer = await _uof.PrayerRepository.Get(p => p.PrayerId == dto.PrayerId);

        if(prayer is null)
            return NotFound(new { success = false, data = "Oração não encontrada" });

        var favorite = await _uof.UserFavoritePrayerRepository.FindByIds(dto, userId);

        if(favorite == null)
        {
            var model = _mapper.Map<UserFavoritePrayer>(dto);
            model.UserId = userId;

            await _uof.UserFavoritePrayerRepository.Create(model);
        }
        else
            await _uof.UserFavoritePrayerRepository.Delete(favorite);

        _uof.Commit();

        return Ok(new { success = true, data = true });
    }
}