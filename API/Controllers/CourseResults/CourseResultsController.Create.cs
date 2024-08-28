using Microsoft.AspNetCore.Mvc;
using Webflow.API.Dto.CourseResults;
using Webflow.API.Dto.Shared;

namespace Webflow.API.Controllers.CourseResults
{
    public partial class CourseResultsController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<BaseResponse<CourseResultView>>> Create(CreateCourseResultRequest request, CancellationToken cancellationToken)
        {
            var result = await courseResultsService.Create(request, cancellationToken);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
