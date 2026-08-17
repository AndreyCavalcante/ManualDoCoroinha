using ManualDoCoroinha.Shared.DTOs.UserCertificates;
using ManualDoCoroinha.Shared.DTOs.UserFavoritePrayers;
using ManualDoCoroinha.Shared.DTOs.UserModules;

namespace ManualDoCoroinha.Shared.DTOs.Users;

public class UserDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string UserName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public DateOnly Birthday { get; set; }

    public DateTime? LastLogin { get; set; }

    public bool IsAdmin { get; set; }

    public string? Token { get; set; }
}
