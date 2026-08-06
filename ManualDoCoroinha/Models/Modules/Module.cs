using ManualDoCoroinha.Enums;
using ManualDoCoroinha.Models.Lessons;
using ManualDoCoroinha.Models.Quizzes;
using ManualDoCoroinha.Models.UserModules;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ManualDoCoroinha.Models.Modules;

public class Module
{
    [Key]
    public Guid ModuleId { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Title { get; set; }

    [Required]
    [StringLength(500, MinimumLength = 10)]
    public string Description { get; set; }

    [Required]
    public ModuleCategory Category { get; set; }

    [Required]
    public int Order { get; set; }

    [Required]
    public bool IsActive { get; set; }

    public Guid? PrerequisiteId { get; set; }

    [JsonIgnore]
    public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();

    [JsonIgnore]
    public Quiz? Quiz { get; set; }

    [JsonIgnore]
    public Module? Prerequisite { get; set; }
}
