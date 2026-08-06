using ManualDoCoroinha.DTOs.Alternatives;

namespace ManualDoCoroinha.DTOs.Questions;

public class QuestionDto
{
    public Guid QuestionId { get; set; }
    public Guid QuizId { get; set; }
    public string Statement { get; set; }
    public int Order { get; set; }
    public ICollection<AlternativeDto> Alternatives { get; set; } = new List<AlternativeDto>();
}
