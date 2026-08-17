using ManualDoCoroinha.Models.Modules;
using ManualDoCoroinha.Models.Questions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ManualDoCoroinha.Models.Quizzes;

public class Quiz
{
    [Key]
    public Guid QuizId { get; set; }

    [Required]
    public Guid ModuleId { get; set; }

    [JsonIgnore]
    public Module Module { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Title { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal MinScore { get; set; }

    [JsonIgnore]
    public ICollection<Question> Questions { get; set; } = new List<Question>();
}
