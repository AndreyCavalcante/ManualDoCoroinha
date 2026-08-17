using ManualDoCoroinha.Shared.Enums;
using ManualDoCoroinha.Models.UserFavoritePrayers;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ManualDoCoroinha.Models.Prayers;

public class Prayer
{
    [Key]
    public Guid PrayerId { get; set; }

    [Required]
    [StringLength(200)]
    public string Title { get; set; }

    [Required]
    public string Content { get; set; }
    [StringLength(100)]
    public string? Author { get; set; }

    [Required]
    public CategoryPrayer Category { get; set; }

    [Required]
    public int Order { get; set; }

    [JsonIgnore]
    public ICollection<UserFavoritePrayer> FavoriteByUsers { get; set; } = new List<UserFavoritePrayer>();

}
