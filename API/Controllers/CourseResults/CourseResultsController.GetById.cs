using Microsoft.AspNetCore.Mvc;
using Webflow.API.Dto.CourseResults;
using Webflow.API.Dto.Shared;

namespace Webflow.API.Controllers.CourseResults
{
    public partial class CourseResultsController : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<CourseResultView>>> GetById(Guid? id, CancellationToken cancellationToken)
        {
            var result = await courseResultsService.GetById(id, cancellationToken);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
