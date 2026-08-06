using AutoMapper;
using ManualDoCoroinha.DTOs.Modules;
using ManualDoCoroinha.Models.Modules;

namespace ManualDoCoroinha.DTOs.Mappings;

public class ModuleDtoMappingProfile : Profile
{
    public ModuleDtoMappingProfile()
    {
        CreateMap<Module, ModuleDto>().ReverseMap();
        CreateMap<Module, CreateModuleDto>().ReverseMap();
    }
}
