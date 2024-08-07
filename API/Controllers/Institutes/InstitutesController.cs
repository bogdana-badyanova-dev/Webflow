using Microsoft.AspNetCore.Mvc;
using Webflow.Application.Services.InstitutesService.Interfaces;

namespace Webflow.API.Controllers.Institutes
{
    /// <summary>
    /// Контроллер для управления институтами.
    /// </summary>
    /// <remarks>
    /// Этот контроллер предоставляет методы для получения, создания, обновления и удаления информации о институтах.
    /// </remarks>
    [Route("api/v1/[controller]")]
    [ApiController]
    public partial class InstitutesController : ControllerBase
    {
        private readonly IInstitutesService institutesService;

        /// <summary>
        /// Конструктор контроллера институтов.
        /// </summary>
        /// <param name="studentsService">Сервис для работы с институтами.</param>
        public InstitutesController(IInstitutesService institutesService)
        {
            this.institutesService = institutesService;
        }
    }
}
