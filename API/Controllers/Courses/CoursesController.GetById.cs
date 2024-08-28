using Microsoft.AspNetCore.Mvc;
using Webflow.API.Dto.Courses;
using Webflow.API.Dto.Shared;

namespace Webflow.API.Controllers.Courses
{
    public partial class CoursesController : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<CourseView>>> GetById(Guid? id, CancellationToken cancellationToken)
        {
            var result = await coursesService.GetById(id, cancellationToken);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
