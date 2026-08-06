using AutoMapper;
using ManualDoCoroinha.DTOs.Alternatives;
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
}
