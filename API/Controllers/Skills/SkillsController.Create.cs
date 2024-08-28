using Microsoft.AspNetCore.Mvc;
using Webflow.API.Dto.Skills;
using Webflow.API.Dto.Shared;

namespace Webflow.API.Controllers.Skills
{
    public partial class SkillsController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<BaseResponse<SkillView>>> Create(CreateSkillRequest request, CancellationToken cancellationToken)
        {
            var result = await skillsService.Create(request, cancellationToken);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
