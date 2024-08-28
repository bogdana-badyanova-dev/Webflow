using Microsoft.AspNetCore.Mvc;
using Webflow.API.Dto.Institutes;
using Webflow.API.Dto.Shared;

namespace Webflow.API.Controllers.Institutes
{
    public partial class InstitutesController : ControllerBase  
    {
        [HttpPost]
        public async Task<ActionResult<BaseResponse<InstituteView>>> Create(CreateInstituteRequest request, CancellationToken cancellationToken)
        {
            var result = await institutesService.Create(request, cancellationToken);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
