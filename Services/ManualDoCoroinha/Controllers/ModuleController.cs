using AutoMapper;
using ManualDoCoroinha.Shared.DTOs.Modules;
using ManualDoCoroinha.Models.Modules;
using ManualDoCoroinha.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ManualDoCoroinha.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ModuleController : ApiController
{
    private readonly IUnitOfWorks _uof;
    private readonly IMapper _mapper;

    public ModuleController(IUnitOfWorks uof, IMapper mapper)
    {
        _uof = uof;
        _mapper = mapper;
    }

    [HttpGet("{page:int}/{take:int}")]
    public async Task<ActionResult<IEnumerable<ModuleDto>>> GetAllCompleted([FromQuery] string? title, int page, int take = 10)
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (!Guid.TryParse(userIdClaim, out var userId))
            return BadRequest(new { success = true, message = "Não autorizado" });

        var modules = await _uof.ModuleRepository.GetAllComplete(userId, page, take, title);
        return Ok(new {success = true, data = modules});
    }

    [HttpPost]
    public async Task<ActionResult<ModuleDto>> Create([FromBody] CreateModuleDto dto)
    {
        if (dto == null)
            return BadRequest(new {success = false, message = "Module is null"});

        var module = _mapper.Map<Module>(dto);
        var newModule = await _uof.ModuleRepository.Create(module);
        _uof.Commit();

        var newModuleDto = _mapper.Map<ModuleDto>(newModule);
        return Ok(new {success = true, data = newModuleDto});
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] ModuleDto moduledto)
    {
        if (moduledto == null)
            return BadRequest(new {success = false, message = "Module is null"});

        var module = _mapper.Map<Module>(moduledto);
        var updatedModule = await _uof.ModuleRepository.Update(module);

        var updatedModuleDto = _mapper.Map<ModuleDto>(updatedModule);

        return Ok(new {success = true, data = updatedModuleDto});
    }

    [HttpPut("disable/{id:guid}")]
    public async Task<ActionResult<ModuleDto>> Disable(Guid id)
    {
        var module = await _uof.ModuleRepository.Get(p => p.ModuleId == id);

        if(module == null)
            return NotFound(new {success = false, message = "Module not found"});

        module.IsActive = !module.IsActive;

        var disabledModule = await _uof.ModuleRepository.Update(module);

        var disabledModuleDto = _mapper.Map<ModuleDto>(disabledModule);
        return Ok(new {success = true, data = disabledModuleDto});
    }
}
