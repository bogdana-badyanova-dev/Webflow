using Microsoft.AspNetCore.Mvc;
using Webflow.Application.Services.FilesService.Interfaces;

namespace Webflow.API.Controllers.Files
{
    /// <summary>
    /// Контроллер для работы с файлами
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public partial class FilesController : ControllerBase
    {
        private readonly IFilesService filesService;

        /// <summary>
        /// Конструктор контроллера для работы с файлами
        /// </summary>
        /// <param name="filesService">Сервис для работы с файлами</param>
        public FilesController(IFilesService filesService)
        {
            this.filesService = filesService;
        }
    }
}
