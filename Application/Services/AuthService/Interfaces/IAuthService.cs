using Webflow.API.Dto.Auth;
using Webflow.API.Dto.Shared;

namespace Webflow.Application.Services.AuthService.Interfaces
{
    /// <summary>
    /// Интерфейс, определяющий методы для работы с аутентификацией
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Метод для регистрации нового пользователя
        /// </summary>
        /// <param name="request">Запрос на регистрацию, содержащий необходимые данные</param>
        /// <param name="cancellationToken">Токен для отмены операции</param>
        /// <returns>Ответ с результатом операции регистрации</returns>
        public Task<BaseResponse<bool>> SignUp(SignUpRequest request, CancellationToken cancellationToken);

        /// <summary>
        /// Метод для входа пользователя в систему
        /// </summary>
        /// <param name="request">Запрос на вход, содержащий email и пароль</param>
        /// <param name="cancellationToken">Токен для отмены операции</param>
        /// <returns>Ответ с результатом операции входа, включая токен и другую информацию</returns>
        public Task<BaseResponse<AuthResult>> SignIn(SignInRequest request, CancellationToken cancellationToken);
    }

}
