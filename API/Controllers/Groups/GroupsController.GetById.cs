using Microsoft.AspNetCore.Mvc;
using Webflow.API.Dto.Groups;
using Webflow.API.Dto.Shared;

namespace Webflow.API.Controllers
{
    public partial class GroupsController : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<GroupView>>> GetById(Guid? id, CancellationToken cancellationToken)
        {
            var result = await groupsService.GetById(id, cancellationToken);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
