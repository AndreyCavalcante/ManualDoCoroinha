using AutoMapper;
using ManualDoCoroinha.DTOs.Alternatives;
using ManualDoCoroinha.Models.Alternatives;

namespace ManualDoCoroinha.DTOs.Mappings;

public class AlternativeDtoMappingsProfile : Profile
{
    public AlternativeDtoMappingsProfile()
    {
        CreateMap<Alternative, AlternativeDto>().ReverseMap();
        CreateMap<Alternative, CreateAlternativeDto>().ReverseMap();
        CreateMap<Alternative, AlternativeSelectedDto>().ReverseMap();
    }
}
