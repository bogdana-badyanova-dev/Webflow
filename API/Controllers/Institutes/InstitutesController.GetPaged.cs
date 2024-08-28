using Microsoft.AspNetCore.Mvc;
using Webflow.API.Dto.Institutes;
using Webflow.API.Dto.Shared;
using Webflow.Domain.Shared;

namespace Webflow.API.Controllers.Institutes
{
    public partial class InstitutesController : ControllerBase
    {
        [HttpPost("paged-institutes")]
        public async Task<ActionResult<BaseResponse<PaginatedResponse<InstituteView>>>> GetPaged(GetPagedInstitutesRequest request, CancellationToken cancellationToken)
        {
            var result = await institutesService.GetPaged(request, cancellationToken);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
