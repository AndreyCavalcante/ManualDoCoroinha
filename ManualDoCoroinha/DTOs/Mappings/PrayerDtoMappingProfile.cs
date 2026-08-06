using AutoMapper;
using ManualDoCoroinha.DTOs.Prayers;
using ManualDoCoroinha.Models.Prayers;

namespace ManualDoCoroinha.DTOs.Mappings;

public class PrayerDtoMappingProfile : Profile
{
    public PrayerDtoMappingProfile()
    {
        CreateMap<Prayer, PrayerDto>().ReverseMap();
        CreateMap<Prayer, CreatePrayerDto>().ReverseMap();
    }
}
