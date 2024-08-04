using Webflow.API.Dto.Auth;
using Webflow.API.Dto.Shared;
using Webflow.Application.Services.AuthService.Interfaces;

namespace Webflow.Application.Services.AuthService.Implementations
{
    public partial class AuthService : IAuthService
    {
        /// <summary>
        /// Метод для регистрации нового пользователя
        /// </summary>
        /// <param name="request">Запрос на регистрацию, содержащий необходимые данные</param>
        /// <param name="cancellationToken">Токен для отмены операции</param>
        /// <returns>Ответ с результатом операции регистрации</returns>
        public async Task<BaseResponse<bool>> SignUp(SignUpRequest request, CancellationToken cancellationToken)
        {
            return await identity.SignUp(request, cancellationToken);
        }
    }

}
