using AutoMapper;
using ManualDoCoroinha.DTOs.UserModules;
using ManualDoCoroinha.Models.UserModules;

namespace ManualDoCoroinha.DTOs.Mappings;

public class UserModuleDtoMappingProfile : Profile
{
    public UserModuleDtoMappingProfile()
    {
        CreateMap<UserModule, UserModuleDto>().ReverseMap();
        CreateMap<UserModule, CreateUserModuleDto>().ReverseMap();
    }
}
