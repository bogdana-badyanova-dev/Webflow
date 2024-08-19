using Microsoft.AspNetCore.Mvc;
using Webflow.Application.Services.Import.Interfaces;

namespace Webflow.API.Controllers.Import
{
    /// <summary>
    /// Контроллер для обработки операций импорта данных.
    /// </summary>
    /// <remarks>
    /// Этот контроллер предоставляет методы для выполнения различных операций по импорту данных, таких как предварительный просмотр данных из Excel-файла и полный импорт данных из Excel-файла.
    /// </remarks>
    [Route("api/[controller]")]
    [ApiController]
    public partial class ImportController : ControllerBase
    {
        private readonly IImportService importService;

        public ImportController(IImportService importService)
        {
            this.importService = importService;
        }
    }
}

