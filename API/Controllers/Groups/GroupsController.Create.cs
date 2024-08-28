using Microsoft.AspNetCore.Mvc;
using Webflow.API.Dto.Groups;
using Webflow.API.Dto.Shared;

namespace Webflow.API.Controllers
{
    public partial class GroupsController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<BaseResponse<GroupView>>> Create(CreateGroupRequest request, CancellationToken cancellationToken)
        {
            var result = await groupsService.Create(request, cancellationToken);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
