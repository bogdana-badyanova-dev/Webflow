using Webflow.API.Dto.CourseResults;
using Webflow.API.Dto.Shared;

namespace Webflow.Application.Services.CourseResultsService.Interfaces
{
    public interface ICourseResultsService
    {
        public Task<BaseResponse<CourseResultView>> Create(CreateCourseResultRequest request, CancellationToken cancellationToken);
        public Task<BaseResponse<CourseResultView>> GetById(Guid? id, CancellationToken cancellationToken);
    }
}
