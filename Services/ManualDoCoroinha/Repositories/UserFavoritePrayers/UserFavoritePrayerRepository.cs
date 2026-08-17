using ManualDoCoroinha.Context;
using ManualDoCoroinha.Shared.DTOs.UserFavoritePrayers;
using ManualDoCoroinha.Models.UserFavoritePrayers;
using Microsoft.EntityFrameworkCore;

namespace ManualDoCoroinha.Repositories.UserFavoritePrayers;

public class UserFavoritePrayerRepository : BaseRepository<UserFavoritePrayer>, IUserFavoritePrayerRepository
{
    public UserFavoritePrayerRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<UserFavoritePrayer?> FindByIds(CreateUserFavoritePrayerDto dto, Guid userId)
    {
        var exists = await _context.UserFavoritePrayers.FirstOrDefaultAsync(x => x.UserId == userId && x.PrayerId == dto.PrayerId);
        return exists;
    }
}
