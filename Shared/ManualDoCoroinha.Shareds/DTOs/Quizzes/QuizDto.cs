using ManualDoCoroinha.Shared.DTOs.Questions;

namespace ManualDoCoroinha.Shared.DTOs.Quizzes;

public class QuizDto
{
    public Guid QuizId { get; set; }
    public Guid ModuleId { get; set; }
    public string Title { get; set; }
    public decimal MinScore { get; set; }
    public ICollection<QuestionDto> Questions { get; set; } = new List<QuestionDto>();
}
