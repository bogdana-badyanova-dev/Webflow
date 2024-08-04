using Microsoft.AspNetCore.Mvc;
using Webflow.Application.Services.StudentsService.Interfaces;

namespace Webflow.API.Controllers.Students
{
    /// <summary>
    /// Контроллер для управления студентами.
    /// </summary>
    /// <remarks>
    /// Этот контроллер предоставляет методы для получения, создания, обновления и удаления информации о студентах.
    /// </remarks>
    [Route("api/v1/[controller]")]
    [ApiController]
    public partial class StudentsController : ControllerBase
    {
        private readonly IStudentsService studentsService;

        /// <summary>
        /// Конструктор контроллера студентов.
        /// </summary>
        /// <param name="studentsService">Сервис для работы со студентами.</param>
        public StudentsController(IStudentsService studentsService)
        {
            this.studentsService = studentsService;
        }
    }

}
