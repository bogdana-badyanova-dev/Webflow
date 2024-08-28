using Microsoft.AspNetCore.Mvc;
using Webflow.API.Dto.Skills;
using Webflow.API.Dto.Shared;
using Webflow.Application.Services.SkillsService.Implementations;

namespace Webflow.API.Controllers.Skills
{
    public partial class SkillsController : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<SkillView>>> GetById(Guid? id, CancellationToken cancellationToken)
        {
            var result = await skillsService.GetById(id, cancellationToken);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
