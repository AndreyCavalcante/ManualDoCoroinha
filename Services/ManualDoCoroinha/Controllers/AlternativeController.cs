using AutoMapper;
using ManualDoCoroinha.Shared.DTOs.Alternatives;
using ManualDoCoroinha.Models.Alternatives;
using ManualDoCoroinha.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ManualDoCoroinha.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class AlternativeController : ApiController
{
    private readonly IUnitOfWorks _uof;
    private readonly IMapper _mapper;

    public AlternativeController(IUnitOfWorks uof, IMapper mapper)
    {
        _uof = uof;
        _mapper = mapper;
    }

    [HttpGet("/{page:int}/{take:int}")]
    public async Task<ActionResult<IEnumerable<AlternativeDto>>> GetAll(int page, int take = 10)
    {
        var result = await _uof.AlternativeRepository.GetAll(page, take);
        var dto = _mapper.Map<IEnumerable<Alternative>>(result.Items);
        result.Items = dto;
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<AlternativeDto>> Post([FromBody] CreateAlternativeDto alternativeDto)
    {
        if (alternativeDto is null)
            return BadRequest(new { success = false, error = "Nenhuma alternativa foi adicionada" });
        var alternative = _mapper.Map<Alternative>(alternativeDto);
        var newAlternative = await _uof.AlternativeRepository.Create(alternative);
        _uof.Commit();
        var dto = _mapper.Map<AlternativeDto>(newAlternative);
        return Ok(new { success = true, data = dto });
    }
}
