using AutoMapper;
using ManualDoCoroinha.Shared.DTOs.Users;
using ManualDoCoroinha.Models.Users;

namespace ManualDoCoroinha.Mappings;

public class UserDtoMappingProfile : Profile
{
    public UserDtoMappingProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
    }
}
