using Microsoft.AspNetCore.Mvc;
using Webflow.API.Dto.Shared;

namespace Webflow.API.Controllers.Files
{
    public partial class FilesController : ControllerBase
    {
        [HttpPost("download")]
        public async Task<ActionResult<BaseResponse<FileResult>>> DownloadFile(Guid fileId, CancellationToken cancellationToken)
        {
            var result = await filesService.DownloadFile(fileId, cancellationToken);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
