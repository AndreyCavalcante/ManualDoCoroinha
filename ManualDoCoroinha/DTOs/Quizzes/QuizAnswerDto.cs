using ManualDoCoroinha.DTOs.Questions;

namespace ManualDoCoroinha.DTOs.Quizzes;

public class QuizAnswerDto
{
    public Guid QuizId { get; set; }
    public Guid ModuleId { get; set; }
    public string Title { get; set; }
    public decimal MinScore { get; set; }
    public ICollection<QuestionAnswerDto> Questions { get; set; }
}