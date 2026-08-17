using ManualDoCoroinha.Shared.DTOs.Lessons;
using ManualDoCoroinha.Shared.DTOs.Modules;
using ManualDoCoroinha.Shared.DTOs.Users;

namespace ManualDoCoroinha.Shared.DTOs.UserModules;

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
