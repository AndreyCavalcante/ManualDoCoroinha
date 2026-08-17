using AutoMapper;
using ManualDoCoroinha.Shared.DTOs.UserModules;
using ManualDoCoroinha.Models.UserModules;

namespace ManualDoCoroinha.Mappings;

public class UserModuleDtoMappingProfile : Profile
{
    public UserModuleDtoMappingProfile()
    {
        CreateMap<UserModule, UserModuleDto>().ReverseMap();
        CreateMap<UserModule, CreateUserModuleDto>().ReverseMap();
    }
}
