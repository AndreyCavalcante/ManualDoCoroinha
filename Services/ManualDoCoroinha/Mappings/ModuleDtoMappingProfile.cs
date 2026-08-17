using AutoMapper;
using ManualDoCoroinha.Shared.DTOs.Modules;
using ManualDoCoroinha.Models.Modules;

namespace ManualDoCoroinha.Mappings;

public class ModuleDtoMappingProfile : Profile
{
    public ModuleDtoMappingProfile()
    {
        CreateMap<Module, ModuleDto>().ReverseMap();
        CreateMap<Module, CreateModuleDto>().ReverseMap();
    }
}
