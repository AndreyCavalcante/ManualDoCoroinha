using AutoMapper;
using ManualDoCoroinha.Shared.DTOs.Quizzes;
using ManualDoCoroinha.Models.Quizzes;
using ManualDoCoroinha.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ManualDoCoroinha.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class QuizController : ApiController
{
    private readonly IUnitOfWorks _uof;
    private readonly IMapper _mapper;

    public QuizController(IUnitOfWorks uof, IMapper mapper)
    {
        _uof = uof;
        _mapper = mapper;
    }

    [HttpGet("{page:int}/{take:int}")]
    public async Task<ActionResult<IEnumerable<QuizDto>>> GetAll(int page, int take = 10)
    {
        var quizzes = await _uof.QuizRepository.GetAll(page, take);
        var dto = _mapper.Map<IEnumerable<Quiz>>(quizzes.Items);
        quizzes.Items = dto;
        return Ok(quizzes);
    }

    [HttpGet]
    [Route("complete-quiz/{id:guid}")]
    public async Task<ActionResult<QuizDto>> GetCompleteQuizByModuleId(Guid id)
    {
        var completeQuiz = await _uof.QuizRepository.GetCompleteQuizyModuleIdB(id);
        if (completeQuiz is null)
            return BadRequest(new { success = false, message = "Nenhum quiz encontrado" } );
        var dto = _mapper.Map<QuizDto>(completeQuiz);
        return Ok(new { success = true, data = dto });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateQuizDto quizDto)
    {
        if (quizDto == null)
            return BadRequest(new { success = false, data = "Quiz não pode ser null"});
        var quiz = _mapper.Map<Quiz>(quizDto);
        var newQuiz = await _uof.QuizRepository.Create(quiz);
        _uof.Commit();
        var dto = _mapper.Map<QuizDto>(newQuiz);
        return Ok(new { success = true, data = dto});
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] QuizDto quizDto)
    {
        if (quizDto is null)
            return BadRequest(new { success = false, data = "Quiz não pode ser null" });
        var quiz = _mapper.Map<Quiz>(quizDto);
        var updatedQuiz = await _uof.QuizRepository.Update(quiz);
        var dto = _mapper.Map<QuizDto>(updatedQuiz);
        return Ok(new { success = true, data = dto});
    }
}
