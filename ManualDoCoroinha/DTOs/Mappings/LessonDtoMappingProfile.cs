using AutoMapper;
using ManualDoCoroinha.DTOs.Lessons;
using ManualDoCoroinha.Models.Lessons;

namespace ManualDoCoroinha.DTOs.Mappings
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
