using ManualDoCoroinha.DTOs.Lessons;
using ManualDoCoroinha.DTOs.Quizzes;
using ManualDoCoroinha.Enums;

namespace ManualDoCoroinha.DTOs.Modules;

public class ModuleDto
{
    public Guid ModuleId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public ModuleCategory Category { get; set; }
    public int Order { get; set; }
    public bool IsActive { get; set; }
    public bool IsCompleted { get; set; }
    public Guid PrerequisiteId { get; set; }
    public bool IsUnlocked { get; set; }
    public ICollection<LessonDto?> Lessons { get; set; } = new List<LessonDto?>();
    public QuizDto? Quiz { get; set; }
}
