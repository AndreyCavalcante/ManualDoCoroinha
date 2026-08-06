using AutoMapper.Configuration.Annotations;
using ManualDoCoroinha.Context;
using ManualDoCoroinha.Models.Questions;
using Microsoft.EntityFrameworkCore;

namespace ManualDoCoroinha.Repositories.Questions;

public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
{
    public QuestionRepository(AppDbContext context) : base(context)
    {
    }

    public IEnumerable<Question> GetByQuizId(Guid id)
    {
        return _context.Questions.AsNoTracking().Where(p => p.QuizId == id).ToList();
    }
}
