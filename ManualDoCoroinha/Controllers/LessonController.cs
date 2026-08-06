using AutoMapper;
using ManualDoCoroinha.DTOs;
using ManualDoCoroinha.DTOs.Lessons;
using ManualDoCoroinha.Models.Lessons;
using ManualDoCoroinha.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ManualDoCoroinha.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class LessonController : ApiController
{
    private readonly IUnitOfWorks _uof;
    private readonly IMapper _mapper;

    public LessonController(IUnitOfWorks uof, IMapper mapper)
    {
        _uof = uof;
        _mapper = mapper;
    }

    [HttpGet("{moduleId:guid}/{page:int}/{take:int}")]
    public async Task<ActionResult<ResponseListDto<LessonDto>>> GetAllByModule([FromQuery] string? title, Guid moduleId, int page, int take = 10)
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (!Guid.TryParse(userIdClaim, out var userId))
            return BadRequest(new { success = true, message = "Não autorizado" });

        var lessons = await _uof.LessonRepository.GetAll(page, take, (l => l.ModuleId == moduleId && (string.IsNullOrEmpty(title) || l.Title.Contains(title))), q => q.OrderBy(l => l.Order));
        return Ok(new { success = true, data = lessons });
    }

    [HttpPost]
    public async Task<ActionResult<LessonDto>> Create([FromBody] CreateLessonDto dto)
    {
        if (dto == null)
            return BadRequest(new { success = false, message = "Lesson é null" });

        var lesson = _mapper.Map<Lesson>(dto);
        var newLesson = await _uof.LessonRepository.Create(lesson);
        _uof.Commit();
        var newLessonDto = _mapper.Map<LessonDto>(newLesson);
        return Ok(new { success = true, data = newLessonDto });
    }

    [HttpPut]
    public async Task<ActionResult<LessonDto>> Put([FromBody] LessonDto lessondto)
    {
        if (lessondto is null)
            return BadRequest(new { success = false, error = "Nenhuma oração foi atualizada" });

        var lesson = _mapper.Map<Lesson>(lessondto);
        var updatedLesson = await _uof.LessonRepository.Update(lesson);

        return Ok(new { success = true, data = updatedLesson });
    }
}
