using ManualDoCoroinha.Models.Quizzes;

namespace ManualDoCoroinha.Repositories.Quizzes;

public interface IQuizRepository : IBaseRepository<Quiz>
{
    Task<Quiz?> GetCompleteQuizyModuleIdB(Guid id);
}
