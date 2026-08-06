using ManualDoCoroinha.Context;
using ManualDoCoroinha.Models.Quizzes;
using Microsoft.EntityFrameworkCore;

namespace ManualDoCoroinha.Repositories.Quizzes;

public class QuizRepository : BaseRepository<Quiz>, IQuizRepository
{
    public QuizRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Quiz?> GetCompleteQuizyModuleIdB(Guid id)
    {
        return await _context.Quizzes
        .AsNoTracking()
        .Include(q => q.Questions)
            .ThenInclude(q => q.Alternatives)
        .FirstOrDefaultAsync(q => q.ModuleId == id);
    }
}
