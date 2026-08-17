using AutoMapper;
using ManualDoCoroinha.Shared.DTOs.Quizzes;
using ManualDoCoroinha.Models.Quizzes;

namespace ManualDoCoroinha.Mappings;

public class QuizDtoMappingProfile : Profile
{
    public QuizDtoMappingProfile()
    {
        CreateMap<Quiz, QuizDto>().ReverseMap();
        CreateMap<CreateQuizDto, Quiz>().ReverseMap();
    }
}
