using System.Web;
using Webflow.API.Dto.Auth;
using Webflow.API.Dto.Shared;
using Webflow.Application.Services.Identity.Interfaces;
using Webflow.Domain.Users;

namespace Webflow.Application.Services.Identity.Implementations
{
    public partial class IdentityService : IIdentityService
    {
        /// <summary>
        /// Регистрация нового пользователя
        /// </summary>
        /// <param name="request">Запрос на регистрацию пользователя</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Результат выполнения операции регистрации</returns>
        public async Task<BaseResponse<bool>> SignUp(SignUpRequest request, CancellationToken cancellationToken)
        {
            var existedUser = await userManager.FindByEmailAsync(request.Email);
            if (existedUser != null)
            {
                throw new Exception("Пользователь с почтой уже существует");
            }

            var newUser = new ApplicationUser
            {
                Email = request.Email,
                UserName = request.Email
            };

            var identityResult = await userManager.CreateAsync(newUser, request.Password);

            if (identityResult.Succeeded)
            {
                var confirmationToken = await userManager.GenerateEmailConfirmationTokenAsync(newUser);
                var encodedToken = HttpUtility.UrlEncode(confirmationToken);

                return new BaseResponse<bool>
                {
                    IsSuccess = true,
                    Data = true
                };
            }

            return new BaseResponse<bool>
            {
                IsSuccess = false,
                Data = false,
                ErrorMessages = new List<string>(identityResult.Errors.Select(x => x.Description))
            };
        }
    }
}
