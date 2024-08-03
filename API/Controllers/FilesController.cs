using Microsoft.AspNetCore.Mvc;
using Webflow.Application.Services.FilesService.Interfaces;

namespace Webflow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {

        private readonly IFilesService filesService;

        public FilesController(IFilesService filesService)
        {
            this.filesService = filesService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Domain.Files.File>> GetFileById(Guid id, CancellationToken cancellationToken)
        {
            var file = await filesService.GetFileByIdAsync(id, cancellationToken);

            if (file == null)
            {
                return NotFound();
            }

            return Ok(file);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Domain.Files.File>>> GetFiles(CancellationToken cancellationToken)
        {
            var files = await filesService.GetFiles(cancellationToken);

            return Ok(files);
        }

        [HttpPost]
        public async Task<ActionResult<Domain.Files.File>> AddFile(Domain.Files.File file, CancellationToken cancellationToken)
        {
            var createdFile = await filesService.AddFileAsync(file, cancellationToken);
            return CreatedAtAction(nameof(GetFileById), createdFile);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteFile(Guid id, CancellationToken cancellationToken)
        {
            var result = await filesService.DeleteFileAsync(id, cancellationToken);
            if (!result)
            {
                return NotFound(result);
            }

            return Ok(result);
        }
    }
}
