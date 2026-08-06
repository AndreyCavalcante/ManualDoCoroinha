using ManualDoCoroinha.Models.Prayers;
using ManualDoCoroinha.Models.Users;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ManualDoCoroinha.Models.UserFavoritePrayers;

public class UserFavoritePrayer
{
    [Key]
    public Guid UserFavoritePrayerId { get; set; }

    [Required]
    public Guid UserId { get; set; }

    [JsonIgnore]
    public User? User { get; set; }

    [Required]
    public Guid PrayerId { get; set; }

    [JsonIgnore]
    public Prayer? Prayer { get; set; }
}
