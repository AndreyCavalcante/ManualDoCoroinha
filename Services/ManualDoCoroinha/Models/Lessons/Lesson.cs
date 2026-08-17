using ManualDoCoroinha.Models.Modules;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ManualDoCoroinha.Models.Lessons;

public class Lesson
{
    [Key]
    public Guid LessonId { get; set; }

    [Required]
    public Guid ModuleId { get; set; }

    [JsonIgnore]
    public Module Module { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters.")]
    public string Title { get; set; }

    [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters.")]
    public string Description { get; set; }

    [Required]
    public string Content { get; set; }

    public string? VideoUrl { get; set; }
    public string? ImageUrl { get; set; }

    [StringLength(300, ErrorMessage = "Verse cannot be longer than 300 characters.")]
    public string? VerseText { get; set; }
    [StringLength(50, ErrorMessage = "Verse cannot be longer than 50 characteres")]
    public string? Verse { get; set; }

    public Guid? PrerequisiteId { get; set; }

    [Required]
    public int Order { get; set; }

    [JsonIgnore]
    public Lesson? Prerequisite { get; set; }
}
