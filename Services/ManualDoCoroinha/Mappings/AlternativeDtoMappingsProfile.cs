using AutoMapper;
using ManualDoCoroinha.Shared.DTOs.Alternatives;
using ManualDoCoroinha.Models.Alternatives;

namespace ManualDoCoroinha.Mappings;

public class AlternativeDtoMappingsProfile : Profile
{
    public AlternativeDtoMappingsProfile()
    {
        CreateMap<Alternative, AlternativeDto>().ReverseMap();
        CreateMap<Alternative, CreateAlternativeDto>().ReverseMap();
        CreateMap<Alternative, AlternativeSelectedDto>().ReverseMap();
    }
}
