using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Webflow.API.Dto.Auth;
using Webflow.API.Dto.Shared;
using Webflow.Application.Services.Identity.Interfaces;

namespace Webflow.Application.Services.Identity.Implementations
{
    public partial class IdentityService : IIdentityService
    {
        /// <summary>
        /// Аутентификация пользователя и получение JWT токена
        /// </summary>
        /// <param name="request">Запрос на вход пользователя</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Результат аутентификации и JWT токен</returns>
        public async Task<BaseResponse<AuthResult>> SignIn([FromBody] SignInRequest request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByEmailAsync(request.Email);

            if (user != null && await userManager.CheckPasswordAsync(user, request.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: configuration["JWT:ValidIssuer"],
                    audience: configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddDays(1),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                var authResult = new AuthResult
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    ExpiryDate = token.ValidTo,
                    TokenType = "Bearer"
                };

                return new BaseResponse<AuthResult>()
                {
                    IsSuccess = true,
                    Data = authResult
                };
            }

            return new BaseResponse<AuthResult>()
            {
                IsSuccess = false,
                Data = null,
                ErrorMessages = new List<string>()
                {
                    "Вы удалось войти в аккаунт"
                }
            };
        }
    }
}
