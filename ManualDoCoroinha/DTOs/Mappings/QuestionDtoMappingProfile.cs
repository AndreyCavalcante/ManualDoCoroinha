using AutoMapper;
using ManualDoCoroinha.DTOs.Questions;
using ManualDoCoroinha.Models.Questions;

namespace ManualDoCoroinha.DTOs.Mappings;

public class QuestionDtoMappingProfile : Profile
{
    public QuestionDtoMappingProfile()
    {
        CreateMap<Question, QuestionDto>().ReverseMap();
        CreateMap<Question, CreateQuestionDto>().ReverseMap();
    }
}
