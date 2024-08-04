using Webflow.Application.Services.AuthService.Interfaces;
using Webflow.Application.Services.Identity.Interfaces;

namespace Webflow.Application.Services.AuthService.Implementations
{
    /// <summary>
    /// Сервис для работы с аутентификацией
    /// </summary>
    public partial class AuthService : IAuthService
    {
        private readonly IIdentityService identity;

        /// <summary>
        /// Конструктор сервиса аутентификации
        /// </summary>
        /// <param name="identity">Сервис для работы с идентификацией пользователей</param>
        public AuthService(IIdentityService identity)
        {
            this.identity = identity;
        }
    }

}
