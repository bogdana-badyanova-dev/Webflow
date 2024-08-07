using Microsoft.AspNetCore.Mvc;
using Webflow.API.Dto.Shared;

namespace Webflow.API.Controllers.Files
{
    public partial class FilesController : ControllerBase
    {
        [HttpDelete("delete")]
        public async Task<ActionResult<BaseResponse<bool>>> DeleteFile(Guid fileId, CancellationToken cancellationToken)
        {
            var result = await filesService.DeleteFile(fileId, cancellationToken);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return NoContent();
        }
    }
}
