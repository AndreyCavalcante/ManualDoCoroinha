using ManualDoCoroinha.Models.Lessons;
using ManualDoCoroinha.Models.Modules;
using ManualDoCoroinha.Models.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ManualDoCoroinha.Models.UserModules;

public class UserModule
{
    [Key]
    public Guid UserModuleId { get; set; }

    [Required]
    public Guid UserId { get; set; }

    [JsonIgnore]
    public User User { get; set; }

    [Required]
    public Guid ModuleId { get; set; }

    [JsonIgnore]
    public Module Module { get; set; }

    [Required]
    public bool Completed { get; set; }

    [Column(TypeName = "decimal(4, 1)")]
    public decimal Progress { get; set; }

    public Guid? LastLessonId { get; set; }

    [JsonIgnore]
    public Lesson? LastLesson { get; set; }

    public bool QuizApproved { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal QuizScore { get; set; }
    public int NumberOfTentatives { get; set; } = 0;
    public bool QuizUnlocked { get; set; } = false;

    [Required]
    public DateTime StartedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
}
