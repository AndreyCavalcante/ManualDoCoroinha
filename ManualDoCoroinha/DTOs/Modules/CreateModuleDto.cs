using ManualDoCoroinha.DTOs.Lessons;
using ManualDoCoroinha.DTOs.Quizzes;
using ManualDoCoroinha.Enums;

namespace ManualDoCoroinha.DTOs.Modules;

public class CreateModuleDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }
    public ModuleCategory Category { get; set; }
    public bool IsActive { get; set; }
    public Guid? PrerequisiteId { get; set; }
}
