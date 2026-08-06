using ManualDoCoroinha.Context;
using ManualDoCoroinha.DTOs;
using ManualDoCoroinha.DTOs.Modules;
using ManualDoCoroinha.Models.Modules;
using Microsoft.EntityFrameworkCore;

namespace ManualDoCoroinha.Repositories.Modules;

public class ModuleRepository : BaseRepository<Module>, IModuleRepository
{
    public ModuleRepository(AppDbContext _context) : base(_context)
    {
    }

    public async Task<ResponseListDto<ModuleDto>> GetAllComplete(Guid id, int page, int take, string? title)
    {
        page = Math.Max(1, page);
        take = Math.Max(1, take);

        var query = _context.Modules
            .AsNoTracking()
            .Where(m => m.IsActive);

        if (!string.IsNullOrWhiteSpace(title))
        {
            query = query.Where(m => m.Title.Contains(title));
        }

        query = query.OrderBy(m => m.Order);

        var totalItems = await query.CountAsync();

        var items = await query
            .Select(m => new ModuleDto
            {
                ModuleId = m.ModuleId,
                Title = m.Title,
                Description = m.Description,
                Category = m.Category,
                Order = m.Order,
                IsActive = m.IsActive,
                PrerequisiteId = m.ModuleId,

                IsCompleted = _context.UserModules
                    .Where(um => um.UserId == id && um.ModuleId == m.ModuleId)
                    .Select(um => um.Completed)
                    .FirstOrDefault(),

                IsUnlocked = m.PrerequisiteId == null ||
                    _context.UserModules.Any(um =>
                        um.UserId == id &&
                        um.ModuleId == m.PrerequisiteId &&
                        um.Completed)
            })
            .Skip((page - 1) * take)
            .Take(take)
            .ToListAsync();

        return new ResponseListDto<ModuleDto>
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
