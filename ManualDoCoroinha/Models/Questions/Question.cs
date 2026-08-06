using ManualDoCoroinha.Models.Alternatives;
using ManualDoCoroinha.Models.Quizzes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ManualDoCoroinha.Models.Questions;

public class Question
{
    [Key]
    public Guid QuestionId { get; set; }

    [Required]
    public Guid QuizId { get; set; }

    [JsonIgnore]
    public Quiz Quiz { get; set; }

    [StringLength(500, ErrorMessage = "A questão deve ter no máximo 500 caracteres.")]
    public string Statement { get; set; }

    [Required]
    public int Order { get; set; }

    [JsonIgnore]
    public ICollection<Alternative> Alternatives { get; set; } = new List<Alternative>();
}
