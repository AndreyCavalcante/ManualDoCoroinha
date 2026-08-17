using ManualDoCoroinha.Models.Questions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ManualDoCoroinha.Models.Alternatives;

public class Alternative
{
    [Key]
    public Guid AlternativeId { get; set; }

    public Guid QuestionId { get; set; }

    [JsonIgnore]
    public Question Question { get; set; }

    [StringLength(500)]
    [Required]
    public string Value { get; set; }

    [Required]
    public bool IsCorrect { get; set; }

    [Required]
    public int Order { get; set; }
}
