using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Webflow.Application.Services.Identity.Interfaces;
using Webflow.Domain.Users;

namespace Webflow.Application.Services.Identity.Implementations
{
    /// <summary>
    /// Сервис для управления аутентификацией и пользователями
    /// </summary>
    public partial class IdentityService : IIdentityService
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
    }
}
