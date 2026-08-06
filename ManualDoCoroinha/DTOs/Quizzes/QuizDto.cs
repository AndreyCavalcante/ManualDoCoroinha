using ManualDoCoroinha.DTOs.Questions;

namespace ManualDoCoroinha.DTOs.Quizzes;

public class QuizDto
{
    public Guid QuizId { get; set; }
    public Guid ModuleId { get; set; }
    public string Title { get; set; }
    public decimal MinScore { get; set; }
    public ICollection<QuestionDto> Questions { get; set; } = new List<QuestionDto>();
}
