namespace ManualDoCoroinha.DTOs.Alternatives;

public class AlternativeDto
{
    public Guid AlternativeId { get; set; }
    public Guid QuestionId { get; set; }
    public string Value { get; set; }
    public bool IsCorrect { get; set; }
    public int Order { get; set; }
}
