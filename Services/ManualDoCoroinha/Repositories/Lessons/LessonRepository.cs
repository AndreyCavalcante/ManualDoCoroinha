using ManualDoCoroinha.Context;
using ManualDoCoroinha.Models.Lessons;

namespace ManualDoCoroinha.Repositories.Lessons;

public class LessonRepository : BaseRepository<Lesson>, ILessonRepository
{
    public LessonRepository(AppDbContext context) : base(context) { }
}
