using AutoMapper;
using ManualDoCoroinha.DTOs.Prayers;
using ManualDoCoroinha.Models.Prayers;
using ManualDoCoroinha.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ManualDoCoroinha.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class PrayerController : ApiController
{
    private readonly IUnitOfWorks _uof;
    private readonly IMapper _mapper;

    public PrayerController(IUnitOfWorks uof, IMapper mapper)
    {
        _uof = uof;
        _mapper = mapper;
    }

    [HttpGet("search/{page:int}/{take:int}")]
    public async Task<ActionResult<IEnumerable<PrayerDto>>> GetPrayersByName([FromQuery] string? search, int page, int take = 10)
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (!Guid.TryParse(userIdClaim, out var userId))
            return BadRequest(new { success = true, message = "Não autorizado" });

        var prayers = await _uof.PrayerRepository.GetPrayesrByName(userId, page, take, search);
        return Ok(new {success = true, data = prayers});
    }

    [HttpGet("search-favorites/{page:int}/{take:int}")]
    public async Task<ActionResult<IEnumerable<PrayerFavoriteDto>>> GetPrayersFavoritesByName([FromQuery] string? search, int page, int take = 10)
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (!Guid.TryParse(userIdClaim, out var userId))
            return BadRequest(new { success = true, message = "Não autorizado" });

        var prayers = await _uof.PrayerRepository.GetFavoritesByName(userId, page, take, search);
        return Ok(new { success = true, data = prayers });
    }

    [HttpPost]
    public async Task<ActionResult<PrayerDto>> Post([FromBody]CreatePrayerDto prayerDto)
    {
        if(prayerDto is null)
            return BadRequest(new { success = false, error = "Nenhuma oração foi adicionada"});

        var prayer = _mapper.Map<Prayer>(prayerDto);
        var newPrayer = await _uof.PrayerRepository.Create(prayer);
        _uof.Commit();

        var dto = _mapper.Map<PrayerDto>(newPrayer);
        return Ok(new { success = true, data = dto });
    }

    [HttpPut]
    public async Task<ActionResult<PrayerDto>> Put([FromBody]PrayerDto prayerdto)
    {
        if(prayerdto is null)
            return BadRequest(new { success = false, error = "Nenhuma oração foi atualizada"});

        var prayer = _mapper.Map<Prayer>(prayerdto);
        var updatedPrayer = await _uof.PrayerRepository.Update(prayer);
        
        return Ok(new { success = true, data = prayerdto });
    }

    [HttpDelete("delete/{id:guid}")]
    public async Task<IActionResult> Delete(Guid prayerId)
    {
        var prayer = await _uof.PrayerRepository.Get(p => p.PrayerId == prayerId);

        if(prayer is null)
            return BadRequest(new { success = false, error = "Nenhuma oração foi encontrada"});

        await _uof.PrayerRepository.Delete(prayer);

        return Ok(new { success = true, data = true });
    }
}
