using AutoMapper;
using ManualDoCoroinha.Shared.DTOs.Quizzes;
using ManualDoCoroinha.Shared.DTOs.UserModules;
using ManualDoCoroinha.Models.UserModules;
using ManualDoCoroinha.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ManualDoCoroinha.Controllers;

[Route("api/[controller]")]
[Authorize]
[ApiController]
public class UserModuleController : ApiController
{
    private readonly IUnitOfWorks _uof;
    private readonly IMapper _mapper;

    public UserModuleController(IUnitOfWorks uof, IMapper mapper)
    {
        _uof = uof;
        _mapper = mapper;
    }

    [HttpGet("{moduleId:guid}")]
    public async Task<ActionResult<UserModuleDto>> Get(Guid moduleId)
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (!Guid.TryParse(userIdClaim, out var userId))
            return BadRequest(new { success = true, message = "Não autorizado" });

        var userModule = await _uof.UserModuleRepository.Get(um => um.UserId == userId && um.ModuleId == moduleId);

        if (userModule == null)
            return BadRequest(new { success = false, message = "Nenhum registro encontrado" });

        return Ok( new { success = true, data = _mapper.Map<UserModuleDto>(userModule) });
    }

    [HttpPost]
    public async Task<ActionResult<UserModuleDto>> Create([FromBody] CreateUserModuleDto dto)
    {
        if (dto == null)
            return BadRequest(new { success = false, message = "Nenhum dado enviado" });

        var newUserModule = await _uof.UserModuleRepository.Create(_mapper.Map<UserModule>(dto));
        _uof.Commit();
        return Ok(new { success = true, data = _mapper.Map<UserModule>(newUserModule) });
    }

    [HttpPatch("{userModuleId:guid}/last-lesson")]
    public async Task<IActionResult> UpdateLastLesson(
    Guid userModuleId,
    [FromBody] UpdateLastLessonDto dto)
    {
        var result = await _uof.UserModuleRepository.UpdateLastLesson(userModuleId, dto);

        if (!result)
            return BadRequest(new { success = false, message = "Erro ao atualizar dados" } );

        return Ok(new { success = true, data = result});
    }

    [HttpPost("{userModuleId:guid}/submit-quiz")]
    public async Task<ActionResult<UserModuleDto>> TakeTheQuiz(Guid userModuleId, [FromBody] QuizAnswerDto dto)
    {
        var result = await _uof.UserModuleRepository.TakeTheQuiz(userModuleId, dto);
        if (result.QuizScore < dto.MinScore || result == null)
            return BadRequest(new { success = false, message = "Pontuação não alcançada" });

        var newDto = _mapper.Map<UserModuleDto>(result);
        return Ok(new { success = true, data = result });
    }
}
