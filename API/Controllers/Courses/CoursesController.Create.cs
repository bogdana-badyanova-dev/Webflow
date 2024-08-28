using Microsoft.AspNetCore.Mvc;
using Webflow.API.Dto.Courses;
using Webflow.API.Dto.Shared;

namespace Webflow.API.Controllers.Courses
{
    public partial class CoursesController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<BaseResponse<CourseView>>> Create(CreateCourseRequest request, CancellationToken cancellationToken)
        {
            var result = await coursesService.Create(request, cancellationToken);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
