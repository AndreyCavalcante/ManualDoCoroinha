using AutoMapper;
using ManualDoCoroinha.Shared.DTOs.Lessons;
using ManualDoCoroinha.Models.Lessons;

namespace ManualDoCoroinha.Mappings
{
    public class LessonDtoMappingProfile : Profile
    {
        public LessonDtoMappingProfile() 
        {
            CreateMap<Lesson, LessonDto>().ReverseMap();
            CreateMap<Lesson, CreateLessonDto>().ReverseMap();
        }
    }
}
