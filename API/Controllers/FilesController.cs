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
        public async Task<ActionResult<Domain.Files.File>> GetFileById(Guid id)
        {
            var file = await filesService.GetFileByIdAsync(id);

            if (file == null)
            {
                return NotFound();
            }

            return Ok(file);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Domain.Files.File>>> GetFiles()
        {
            var files = await filesService.GetFiles();

            return Ok(files);
        }

        [HttpPost]
        public async Task<ActionResult<Domain.Files.File>> AddFile(Domain.Files.File file)
        {
            var createdFile = await filesService.AddFileAsync(file);
            return CreatedAtAction(nameof(GetFileById), createdFile);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteFile(Guid id)
        {
            var result = await filesService.DeleteFileAsync(id);
            if (!result)
            {
                return NotFound(result);
            }

            return Ok(result);
        }
    }
}
