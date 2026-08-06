using ManualDoCoroinha.DTOs;
using ManualDoCoroinha.DTOs.Lessons;
using ManualDoCoroinha.Models.Lessons;

namespace ManualDoCoroinha.Repositories.Lessons;

public interface ILessonRepository : IBaseRepository<Lesson>
{
    //Task<ResponseListDto<LessonDto>> GetAllByModuleId(Guid userId, Guid moduleId, int page, int take, string title);
}
