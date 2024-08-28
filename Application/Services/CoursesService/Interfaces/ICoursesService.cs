using Webflow.API.Dto.Courses;
using Webflow.API.Dto.Shared;

namespace Webflow.Application.Services.CoursesService.Interfaces
{
    public interface ICoursesService
    {
        public Task<BaseResponse<CourseView>> Create(CreateCourseRequest request, CancellationToken cancellationToken);
        public Task<BaseResponse<CourseView>> GetById(Guid? id, CancellationToken cancellationToken);
    }
}
