using AutoMapper;
using ManualDoCoroinha.DTOs.UserFavoritePrayers;
using ManualDoCoroinha.Models.UserFavoritePrayers;

namespace ManualDoCoroinha.DTOs.Mappings;

public class FavoritePrayerDtoMappingProfile : Profile
{
    public FavoritePrayerDtoMappingProfile()
    {
        CreateMap<UserFavoritePrayer, UserFavoritePrayerDto>().ReverseMap();
        CreateMap<UserFavoritePrayer, CreateUserFavoritePrayerDto>().ReverseMap();
    }
}
