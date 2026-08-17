using AutoMapper;
using ManualDoCoroinha.Shared.DTOs.Prayers;
using ManualDoCoroinha.Models.Prayers;

namespace ManualDoCoroinha.Mappings;

public class PrayerDtoMappingProfile : Profile
{
    public PrayerDtoMappingProfile()
    {
        CreateMap<Prayer, PrayerDto>().ReverseMap();
        CreateMap<Prayer, CreatePrayerDto>().ReverseMap();
    }
}
