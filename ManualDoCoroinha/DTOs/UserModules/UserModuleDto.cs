using ManualDoCoroinha.DTOs.Lessons;
using ManualDoCoroinha.DTOs.Modules;
using ManualDoCoroinha.DTOs.Users;

namespace ManualDoCoroinha.DTOs.UserModules;

public class UserModuleDto
{
    public Guid UserModuleId { get; set; }
    public Guid UserId { get; set; }
    public Guid ModuleId { get; set; }
    public bool Completed { get; set; }
    public decimal Progress { get; set; }
    public Guid? LastLessonId { get; set; }
    public bool QuizApproved { get; set; }
    public decimal QuizScore { get; set; }
    public bool QuizUnlocked { get; set; }
    public int NumberOfTentatives { get; set; }
    public DateTime StartedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
}
