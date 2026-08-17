namespace ManualDoCoroinha.Shared.DTOs.Lessons;

public class LessonDto
{
    public Guid LessonId { get; set; }
    public Guid ModuleId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Content { get; set; }
    public string? VideoUrl { get; set; }
    public string? ImageUrl { get; set; }
    public string? VerseText { get; set; }
    public string? Verse { get; set; }
    public Guid? PrerequisiteId { get; set; }
    public int Order { get; set; }
}
