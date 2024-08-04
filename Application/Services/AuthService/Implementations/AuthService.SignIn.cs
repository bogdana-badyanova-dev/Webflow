using Webflow.API.Dto.Auth;
using Webflow.API.Dto.Shared;
using Webflow.Application.Services.AuthService.Interfaces;

namespace Webflow.Application.Services.AuthService.Implementations
{
    public partial class AuthService : IAuthService
    {
        /// <summary>
        /// Метод для входа пользователя в систему
        /// </summary>
        /// <param name="request">Запрос на вход, содержащий email и пароль</param>
        /// <param name="cancellationToken">Токен для отмены операции</param>
        /// <returns>Ответ с результатом операции входа, включая токен и другую информацию</returns>
        public async Task<BaseResponse<AuthResult>> SignIn(SignInRequest request, CancellationToken cancellationToken)
        {
            return await identity.SignIn(request, cancellationToken);
        }
    }

}
