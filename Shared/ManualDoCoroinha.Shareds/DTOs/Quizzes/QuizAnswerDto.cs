using ManualDoCoroinha.Shared.DTOs.Questions;

namespace ManualDoCoroinha.Shared.DTOs.Quizzes;

public class QuizAnswerDto
{
    public Guid QuizId { get; set; }
    public Guid ModuleId { get; set; }
    public string Title { get; set; }
    public decimal MinScore { get; set; }
    public ICollection<QuestionAnswerDto> Questions { get; set; }
}