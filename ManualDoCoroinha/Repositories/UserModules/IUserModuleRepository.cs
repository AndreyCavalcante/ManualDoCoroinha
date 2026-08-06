using ManualDoCoroinha.DTOs.Quizzes;
using ManualDoCoroinha.DTOs.UserModules;
using ManualDoCoroinha.Models.UserModules;

namespace ManualDoCoroinha.Repositories.UserModules;

public interface IUserModuleRepository : IBaseRepository<UserModule>
{
    Task<bool> UpdateLastLesson(Guid userModuleId, UpdateLastLessonDto dto);
    Task<UserModule> TakeTheQuiz(Guid userModuleId, QuizAnswerDto dto);
}
