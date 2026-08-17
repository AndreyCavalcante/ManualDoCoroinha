namespace ManualDoCoroinha.Shared.DTOs.UserModules;

public class CreateUserModuleDto
{
    public Guid UserId { get; set; }
    public Guid ModuleId { get; set; }
    public bool Completed { get; set; } = false;
    public decimal? Progress { get; set; }
    public Guid? LastLessonId { get; set; }
    public bool? QuizApproved { get; set; }
    public decimal? QuizScore { get; set; }
    public int NumberOfTentatives { get; set; } = 0;
    public DateTime StartedAt { get; set; } = DateTime.UtcNow;
    public DateTime? CompletedAt { get; set; }
}
