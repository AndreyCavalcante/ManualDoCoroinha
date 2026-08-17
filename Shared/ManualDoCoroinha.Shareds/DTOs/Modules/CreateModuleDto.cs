using ManualDoCoroinha.Shared.DTOs.Lessons;
using ManualDoCoroinha.Shared.DTOs.Quizzes;
using ManualDoCoroinha.Shared.Enums;

namespace ManualDoCoroinha.Shared.DTOs.Modules;

public class CreateModuleDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }
    public ModuleCategory Category { get; set; }
    public bool IsActive { get; set; }
    public Guid? PrerequisiteId { get; set; }
}
