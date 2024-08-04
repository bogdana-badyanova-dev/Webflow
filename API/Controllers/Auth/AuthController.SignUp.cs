using Microsoft.AspNetCore.Mvc;
using Webflow.API.Dto.Auth;

namespace Webflow.API.Controllers.Auth
{
    public partial class AuthController : ControllerBase
    {
        /// <summary>
        /// Регистрация нового пользователя
        /// </summary>
        /// <param name="request">Запрос на регистрацию, содержащий email и пароль</param>
        /// <param name="cancellationToken">Токен для отмены операции</param>
        /// <returns>Результат операции регистрации</returns>
        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(
            [FromBody] SignUpRequest request,
            CancellationToken cancellationToken)
        {
            var response = await authService.SignUp(request, cancellationToken);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
