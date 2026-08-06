namespace ManualDoCoroinha.DTOs.Questions;

public class CreateQuestionDto
{
    public Guid QuizId { get; set; }
    public string Statement { get; set; }
    public int Order { get; set; }
}
