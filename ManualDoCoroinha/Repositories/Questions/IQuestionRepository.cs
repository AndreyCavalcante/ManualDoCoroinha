using ManualDoCoroinha.Models.Questions;

namespace ManualDoCoroinha.Repositories.Questions;

public interface IQuestionRepository : IBaseRepository<Question>
{
    IEnumerable<Question> GetByQuizId(Guid id);
}
