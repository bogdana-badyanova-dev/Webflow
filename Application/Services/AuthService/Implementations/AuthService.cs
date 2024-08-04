using Webflow.API.Dto.Auth;
using Webflow.API.Dto.Shared;
using Webflow.Application.Services.AuthService.Interfaces;
using Webflow.Application.Services.Identity.Interfaces;

namespace Webflow.Application.Services.AuthService.Implementations
{
    /// <summary>
    /// Сервис для работы с аутентификацией
    /// </summary>
    public class AuthService : IAuthService
    {
        private readonly IIdentityService _identity;

        /// <summary>
        /// Конструктор сервиса аутентификации
        /// </summary>
        /// <param name="identity">Сервис для работы с идентификацией пользователей</param>
        public AuthService(IIdentityService identity)
        {
            _identity = identity;
        }

        /// <summary>
        /// Метод для регистрации нового пользователя
        /// </summary>
        /// <param name="request">Запрос на регистрацию, содержащий необходимые данные</param>
        /// <param name="cancellationToken">Токен для отмены операции</param>
        /// <returns>Ответ с результатом операции регистрации</returns>
        public async Task<BaseResponse<bool>> SignUp(SignUpRequest request, CancellationToken cancellationToken)
        {
            return await _identity.SignUp(request, cancellationToken);
        }

        /// <summary>
        /// Метод для входа пользователя в систему
        /// </summary>
        /// <param name="request">Запрос на вход, содержащий email и пароль</param>
        /// <param name="cancellationToken">Токен для отмены операции</param>
        /// <returns>Ответ с результатом операции входа, включая токен и другую информацию</returns>
        public async Task<BaseResponse<AuthResult>> SignIn(SignInRequest request, CancellationToken cancellationToken)
        {
            return await _identity.SignIn(request, cancellationToken);
        }
    }

}
