using Microsoft.AspNetCore.Mvc;
using Webflow.Application.Services.AuthService.Interfaces;

namespace Webflow.API.Controllers.Auth
{
    /// <summary>
    /// Контроллер для обработки запросов аутентификации
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public partial class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        /// <summary>
        /// Конструктор контроллера аутентификации
        /// </summary>
        /// <param name="authService">Сервис для работы с аутентификацией</param>
        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }
    }
}
