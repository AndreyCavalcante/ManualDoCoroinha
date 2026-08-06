using AutoMapper;
using ManualDoCoroinha.DTOs.Users;
using ManualDoCoroinha.Models.Users;

namespace ManualDoCoroinha.DTOs.Mappings;

public class UserDtoMappingProfile : Profile
{
    public UserDtoMappingProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
    }
}
