using AutoMapper;
using ManualDoCoroinha.Shared.DTOs.Questions;
using ManualDoCoroinha.Models.Questions;

namespace ManualDoCoroinha.Mappings;

public class QuestionDtoMappingProfile : Profile
{
    public QuestionDtoMappingProfile()
    {
        CreateMap<Question, QuestionDto>().ReverseMap();
        CreateMap<Question, CreateQuestionDto>().ReverseMap();
    }
}
