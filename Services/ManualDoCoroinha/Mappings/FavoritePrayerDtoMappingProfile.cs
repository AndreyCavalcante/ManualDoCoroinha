using AutoMapper;
using ManualDoCoroinha.Shared.DTOs.UserFavoritePrayers;
using ManualDoCoroinha.Models.UserFavoritePrayers;

namespace ManualDoCoroinha.Mappings;

public class FavoritePrayerDtoMappingProfile : Profile
{
    public FavoritePrayerDtoMappingProfile()
    {
        CreateMap<UserFavoritePrayer, UserFavoritePrayerDto>().ReverseMap();
        CreateMap<UserFavoritePrayer, CreateUserFavoritePrayerDto>().ReverseMap();
    }
}
