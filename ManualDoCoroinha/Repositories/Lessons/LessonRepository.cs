using ManualDoCoroinha.Context;
using ManualDoCoroinha.DTOs;
using ManualDoCoroinha.DTOs.Lessons;
using ManualDoCoroinha.DTOs.Modules;
using ManualDoCoroinha.Models.Lessons;
using Microsoft.EntityFrameworkCore;

namespace ManualDoCoroinha.Repositories.Lessons;

public class LessonRepository : BaseRepository<Lesson>, ILessonRepository
{
    public LessonRepository(AppDbContext context) : base(context) { }

    //public async Task<ResponseListDto<LessonDto>> GetAllByModuleId(Guid userId, Guid moduleId, int page, int take, string title)
    //{
    //    page = Math.Max(1, page);
    //    take = Math.Max(1, take);

    //    var query = _context.Lessons
    //        .AsNoTracking()
    //        .Where(l => l.ModuleId == moduleId);

    //    if (!string.IsNullOrWhiteSpace(title))
    //    {
    //        query = query.Where(m => m.Title.Contains(title));
    //    }

    //    query = query.OrderBy(m => m.Order);

    //    var totalItems = await query.CountAsync();

    //    var items = await query
    //        .Select(l => new LessonDto
    //        {
    //            LessonId = l.LessonId,
    //            Title = l.Title,
    //            Content = l.Content,

    //        })
    //        .Skip((page - 1) * take)
    //        .Take(take)
    //        .ToListAsync();

    //    return new ResponseListDto<ModuleDto>
    //    {
    //        Items = items,
    //        CurrentPage = page,
    //        PageSize = take,
    //        TotalItems = totalItems,
    //        TotalPages = (int)Math.Ceiling(totalItems / (double)take),
    //        HasMore = page * take < totalItems
    //    };
    //}
}
