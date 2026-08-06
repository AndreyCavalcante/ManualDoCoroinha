using ManualDoCoroinha.Models.UserCertificates;
using ManualDoCoroinha.Models.UserFavoritePrayers;
using ManualDoCoroinha.Models.UserModules;
using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace ManualDoCoroinha.Models.Users;

public class User : IdentityUser<Guid>
{
    public string Name { get; set; } = string.Empty;

    public DateOnly Birthday { get; set; }

    public DateTime? LastLogin { get; set; }

    public bool IsAdmin { get; set; }

    public string? RefreshToken { get; set; }

    public DateTime? RefreshTokenExpiryTime { get; set; }

    [JsonIgnore]
    public ICollection<UserModule> UserModules { get; set; } = [];

    [JsonIgnore]
    public ICollection<UserCertificate> UserCertificates { get; set; } = [];

    [JsonIgnore]
    public ICollection<UserFavoritePrayer> FavoritePrayers { get; set; } = [];
}