using AutoMapper;
using Webflow.API.Dto.CourseResults;
using Webflow.Domain.CourseResults;
using Webflow.Domain.Shared;

namespace Webflow.Application.Mappings
{
    public class CourseResultMappingProfile : Profile
    {
        public CourseResultMappingProfile()
        {
            CreateMap<CourseResult, CourseResultView>();
            CreateMap<CreateCourseResultRequest, CourseResult>();
            CreateMap<PaginatedResponse<CourseResult>, PaginatedResponse<CourseResultView>>();
        }
    }
}
