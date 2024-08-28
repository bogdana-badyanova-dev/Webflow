using AutoMapper;
using Webflow.API.Dto.Courses;
using Webflow.Domain.Shared;
using Webflow.Domain.Cources;

namespace Webflow.Application.Mappings
{
    public class CourseMappingProfile : Profile
    {
        public CourseMappingProfile()
        {
            CreateMap<Course, CourseView>();
            CreateMap<CreateCourseRequest, Course>();
            CreateMap<PaginatedResponse<Course>, PaginatedResponse<CourseView>>();
        }
    }
}
