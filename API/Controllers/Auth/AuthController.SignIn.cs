using Microsoft.AspNetCore.Mvc;
using Webflow.API.Dto.Auth;
using Webflow.API.Dto.Shared;

namespace Webflow.API.Controllers.Auth
{
    public partial class AuthController : ControllerBase
    {
        /// <summary>
        /// Вход пользователя в систему
        /// </summary>
        /// <param name="request">Запрос на вход, содержащий email и пароль</param>
        /// <param name="cancellationToken">Токен для отмены операции</param>
        /// <returns>Результат операции входа, включая токен и другую информацию</returns>
        [HttpPost("signin")]
        public async Task<ActionResult<BaseResponse<AuthResult>>> SignIn(
            [FromBody] SignInRequest request,
            CancellationToken cancellationToken)
        {
            var response = await authService.SignIn(request, cancellationToken);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
