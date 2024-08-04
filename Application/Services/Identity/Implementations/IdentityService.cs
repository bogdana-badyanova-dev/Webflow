using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Web;
using Webflow.API.Dto.Auth;
using Webflow.API.Dto.Shared;
using Webflow.Application.Services.Identity.Interfaces;
using Webflow.Domain.Users;

namespace Webflow.Application.Services.Identity.Implementations
{
    /// <summary>
    /// Сервис для управления аутентификацией и пользователями
    /// </summary>
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration configuration;

        /// <summary>
        /// Конструктор сервиса IdentityService
        /// </summary>
        /// <param name="userManager">Менеджер пользователей для работы с ApplicationUser</param>
        /// <param name="configuration">Конфигурация приложения для доступа к настройкам</param>
        public IdentityService(
            UserManager<ApplicationUser> userManager,
            IConfiguration configuration
            )
        {
            this.userManager = userManager;
            this.configuration = configuration;
        }

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
