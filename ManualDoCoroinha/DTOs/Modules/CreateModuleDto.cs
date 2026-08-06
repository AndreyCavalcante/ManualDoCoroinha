using ManualDoCoroinha.DTOs.Lessons;
using ManualDoCoroinha.DTOs.Quizzes;

namespace ManualDoCoroinha.DTOs.Modules;

public class CreateModuleDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }
    public bool IsActive { get; set; }
    public bool PrerequisiteId { get; set; }
}
