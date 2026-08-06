using ManualDoCoroinha.DTOs;
using ManualDoCoroinha.DTOs.Modules;
using ManualDoCoroinha.Models.Modules;

namespace ManualDoCoroinha.Repositories.Modules;

public interface IModuleRepository : IBaseRepository<Module>
{
    Task<ResponseListDto<ModuleDto>> GetAllComplete(Guid id, int page, int take, string title);
}
