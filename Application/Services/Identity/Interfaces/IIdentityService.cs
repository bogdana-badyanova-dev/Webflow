using Webflow.API.Dto.Auth;
using Webflow.API.Dto.Shared;

namespace Webflow.Application.Services.Identity.Interfaces
{
    /// <summary>
    /// Интерфейс для работы с идентификацией пользователей
    /// </summary>
    public interface IIdentityService
    {
        /// <summary>
        /// Регистрация нового пользователя
        /// </summary>
        /// <param name="request">Запрос на регистрацию нового пользователя</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Результат выполнения операции регистрации</returns>
        Task<BaseResponse<bool>> SignUp(SignUpRequest request, CancellationToken cancellationToken);

        /// <summary>
        /// Аутентификация пользователя и получение JWT токена
        /// </summary>
        /// <param name="request">Запрос на вход пользователя</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Результат аутентификации и JWT токен</returns>
        Task<BaseResponse<AuthResult>> SignIn(SignInRequest request, CancellationToken cancellationToken);
    }

}
