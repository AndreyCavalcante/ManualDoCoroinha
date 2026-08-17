using ManualDoCoroinha.Context;
using ManualDoCoroinha.Shared.DTOs;
using ManualDoCoroinha.Shared.DTOs.Prayers;
using ManualDoCoroinha.Models.Prayers;
using Microsoft.EntityFrameworkCore;

namespace ManualDoCoroinha.Repositories.Prayers;

public class PrayerRepository : BaseRepository<Prayer>, IPrayerRepository
{
    public PrayerRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<ResponseListDto<PrayerDto>> GetAllPrayers(Guid id, int page, int take)
    {
        page = Math.Max(1, page);
        take = Math.Max(1, take);

        var query = _context.Prayers
            .AsNoTracking()
            .OrderBy(p => p.Order);

        var totalItems = await query.CountAsync();

        var items = await query
            .Skip((page - 1) * take)
            .Take(take)
            .Select(p => new PrayerDto
            {
                PrayerId = p.PrayerId,
                Title = p.Title,
                Content = p.Content,
                Author = p.Author,
                Category = p.Category,
                Order = p.Order,
                IsFavorite = p.FavoriteByUsers.Any(f => f.UserId == id)
            })
            .ToListAsync();

        return new ResponseListDto<PrayerDto>
        {
            Items = items,
            CurrentPage = page,
            PageSize = take,
            TotalItems = totalItems,
            TotalPages = (int)Math.Ceiling(totalItems / (double)take),
            HasMore = page * take < totalItems
        };
    }

    public async Task<ResponseListDto<PrayerFavoriteDto>> GetFavoritesByUserId(Guid id, int page, int take)
    {
        page = Math.Max(1, page);
        take = Math.Max(1, take);

        var query = _context.Prayers
            .AsNoTracking()
            .Where(p => p.FavoriteByUsers.Any(f => f.UserId == id))
            .OrderBy(p => p.Order);

        var totalItems = await query.CountAsync();

        var items = await query
            .Select(p => new PrayerFavoriteDto
            {
                PrayerId = p.PrayerId,
                Title = p.Title,
                Content = p.Content,
                Author = p.Author,
                Category = p.Category,
                Order = p.Order,
                IsFavorite = true,
                UserFavoritePrayerId = p.FavoriteByUsers
                    .First(f => f.UserId == id)
                    .UserFavoritePrayerId
            })
            .Skip((page - 1) * take)
            .Take(take)
            .ToListAsync();

        return new ResponseListDto<PrayerFavoriteDto>
        {
            Items = items,
            CurrentPage = page,
            PageSize = take,
            TotalItems = totalItems,
            TotalPages = (int)Math.Ceiling(totalItems / (double)take),
            HasMore = page * take < totalItems
        };
    }

    public async Task<ResponseListDto<PrayerDto>> GetPrayesrByName(Guid id, int page, int take, string search)
    {
        page = Math.Max(1, page);
        take = Math.Max(1, take);

        var query = _context.Prayers
            .AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(p => p.Title.Contains(search));
        }

        query = query.OrderBy(p => p.Order);

        var totalItems = await query.CountAsync();

        var items = await query
            .Skip((page - 1) * take)
            .Take(take)
            .Select(p => new PrayerDto
            {
                PrayerId = p.PrayerId,
                Title = p.Title,
                Content = p.Content,
                Author = p.Author,
                Category = p.Category,
                Order = p.Order,
                IsFavorite = p.FavoriteByUsers.Any(f => f.UserId == id)
            })
            .ToListAsync();

        return new ResponseListDto<PrayerDto>
        {
            Items = items,
            CurrentPage = page,
            PageSize = take,
            TotalItems = totalItems,
            TotalPages = (int)Math.Ceiling(totalItems / (double)take),
            HasMore = page * take < totalItems
        };
    }

    public async Task<ResponseListDto<PrayerFavoriteDto>> GetFavoritesByName(Guid id, int page, int take, string search)
    {
        page = Math.Max(1, page);
        take = Math.Max(1, take);

        var query = _context.Prayers
            .AsNoTracking()
            .Where(p => p.FavoriteByUsers.Any(f => f.UserId == id));

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(p => p.Title.Contains(search));
        }

        query = query.OrderBy(p => p.Order);

        var totalItems = await query.CountAsync();

        var items = await query
            .Select(p => new PrayerFavoriteDto
            {
                PrayerId = p.PrayerId,
                Title = p.Title,
                Content = p.Content,
                Author = p.Author,
                Category = p.Category,
                Order = p.Order,
                IsFavorite = true,
                UserFavoritePrayerId = p.FavoriteByUsers
                    .First(f => f.UserId == id)
                    .UserFavoritePrayerId
            })
            .Skip((page - 1) * take)
            .Take(take)
            .ToListAsync();

        return new ResponseListDto<PrayerFavoriteDto>
        {
            Items = items,
            CurrentPage = page,
            PageSize = take,
            TotalItems = totalItems,
            TotalPages = (int)Math.Ceiling(totalItems / (double)take),
            HasMore = page * take < totalItems
        };
    }
}
