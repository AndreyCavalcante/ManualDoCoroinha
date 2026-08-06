using ManualDoCoroinha.Context;
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

public class UnitOfWorks : IUnitOfWorks
{
    private readonly IUserRepository _userRepository;
    private readonly IPrayerRepository _prayerRepository;
    private readonly IUserFavoritePrayerRepository _userFavoritePrayerRepository;
    private readonly IModuleRepository _moduleRepository;
    private readonly IQuizRepository _quizRepository;
    private readonly IQuestionRepository _questionRepository;
    private readonly IAlternativeRepository _alternativeRepository;
    private readonly ILessonRepository _lessonRepository;
    private readonly IUserModuleRepository _userModuleRepository;

    public AppDbContext _context;

    public UnitOfWorks(AppDbContext context)
    {
        _context = context;
    }

    public IUserRepository UserRepository { get { return _userRepository ?? new UserRepository(_context); } }
    public IPrayerRepository PrayerRepository { get { return _prayerRepository ?? new PrayerRepository(_context); } }
    public IUserFavoritePrayerRepository UserFavoritePrayerRepository { get { return _userFavoritePrayerRepository ?? new UserFavoritePrayerRepository(_context); } }
    public IModuleRepository ModuleRepository { get { return _moduleRepository ?? new ModuleRepository(_context); } }
    public IQuizRepository QuizRepository { get { return _quizRepository ?? new QuizRepository(_context); } }
    public IQuestionRepository QuestionRepository { get { return _questionRepository ?? new QuestionRepository(_context); } }
    public IAlternativeRepository AlternativeRepository { get { return _alternativeRepository ?? new AlternativeRepository(_context); } }
    public ILessonRepository LessonRepository { get { return _lessonRepository ?? new LessonRepository(_context); } }
    public IUserModuleRepository UserModuleRepository { get { return _userModuleRepository ?? new UserModuleRepository(_context); } }

    public void Commit()
    {
        _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
