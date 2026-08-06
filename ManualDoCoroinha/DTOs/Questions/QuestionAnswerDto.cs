using ManualDoCoroinha.DTOs.Alternatives;

namespace ManualDoCoroinha.DTOs.Questions;

public class QuestionAnswerDto
{
    public Guid QuestionId { get; set; }
    public Guid QuizId { get; set; }
    public string Statement { get; set; }
    public int Order { get; set; }
    public AlternativeSelectedDto AlternativeSelected { get; set; }
}
