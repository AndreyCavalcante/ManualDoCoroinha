using ManualDoCoroinha.Repositories.Alternatives;
using ManualDoCoroinha.Repositories.Lessons;
using ManualDoCoroinha.Repositories.Modules;
using ManualDoCoroinha.Repositories.Prayers;
using ManualDoCoroinha.Repositories.Questions;
using ManualDoCoroinha.Repositories.Quizzes;
using ManualDoCoroinha.Repositories.UserFavoritePrayers;
using ManualDoCoroinha.Repositories.UserModules;
using ManualDoCoroinha.Repositories.Users;

namespace ManualDoCoroinha.Repositories;

public interface IUnitOfWorks
{
    IUserRepository UserRepository { get; }
    IPrayerRepository PrayerRepository { get; }
    IUserFavoritePrayerRepository UserFavoritePrayerRepository { get; }
    IModuleRepository ModuleRepository { get; }
    IQuizRepository QuizRepository { get; }
    IQuestionRepository QuestionRepository { get; }
    IAlternativeRepository AlternativeRepository { get; }
    ILessonRepository LessonRepository { get; }
    IUserModuleRepository UserModuleRepository { get; }

    void Commit();
}
