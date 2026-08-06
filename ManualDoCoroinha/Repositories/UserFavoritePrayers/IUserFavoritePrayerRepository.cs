using ManualDoCoroinha.DTOs.UserFavoritePrayers;
using ManualDoCoroinha.Models.UserFavoritePrayers;

namespace ManualDoCoroinha.Repositories.UserFavoritePrayers;

public interface IUserFavoritePrayerRepository : IBaseRepository<UserFavoritePrayer>
{
    Task<UserFavoritePrayer?> FindByIds(CreateUserFavoritePrayerDto dto, Guid userId);
}
