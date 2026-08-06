using AutoMapper;
using ManualDoCoroinha.DTOs.Quizzes;
using ManualDoCoroinha.Models.Quizzes;

namespace ManualDoCoroinha.DTOs.Mappings;

public class QuizDtoMappingProfile : Profile
{
    public QuizDtoMappingProfile()
    {
        CreateMap<Quiz, QuizDto>().ReverseMap();
        CreateMap<CreateQuizDto, Quiz>().ReverseMap();
    }
}
