namespace ManualDoCoroinha.DTOs.Quizzes;

public class CreateQuizDto
{
    public Guid ModuleId { get; set; }
    public string Title { get; set; }
    public decimal MinScore { get; set; }
}
