using AutoMapper;
using ManualDoCoroinha.DTOs.Questions;
using ManualDoCoroinha.Models.Questions;
using ManualDoCoroinha.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ManualDoCoroinha.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class QuestionController : ApiController
{
    private readonly IUnitOfWorks _uof;
    private readonly IMapper _mapper;

    public QuestionController(IUnitOfWorks uof, IMapper mapper)
    {
        _uof = uof;
        _mapper = mapper;
    }

    [HttpGet("{page:int}/{take:int}")]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> GetAll(int page, int take = 10)
    {
        var questions = await _uof.QuestionRepository.GetAll(page, take);
        var dto = _mapper.Map<IEnumerable<Question>>(questions.Items);
        questions.Items = dto;
        return Ok(questions);
    }

    [HttpPost]
    public async Task<ActionResult<QuestionDto>> Create([FromBody] CreateQuestionDto questionDto)
    {
        if (questionDto is null)
            return BadRequest(new { success = false, message = "Nenhum dado enviado!" } );

        var quiz = await _uof.QuizRepository.Get(p => p.QuizId == questionDto.QuizId);

        if (quiz is null)
            return BadRequest(new { success = true, message = "Nenhum quiz encontrado com esse id." } );

        var question = _mapper.Map<Question>(questionDto);
        var newQuestion = await _uof.QuestionRepository.Create(question);
        _uof.Commit();
        var dto = _mapper.Map<Question>(newQuestion);

        return Ok(new { success = true, data = dto } );
    }

    [HttpPut]
    public async Task<ActionResult<QuestionDto>> Update([FromBody] QuestionDto questionDto)
    {
        if (questionDto is null)
            return BadRequest(new { success = false, message = "Nenhum dado enviado!" });

        var question = _mapper.Map<Question>(questionDto);
        var updated = await _uof.QuestionRepository.Update(question);
        var dto = _mapper.Map<Question>(updated);

        return Ok(new { success = true, data = dto });
    }
}
