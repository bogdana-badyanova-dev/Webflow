using Microsoft.AspNetCore.Identity;

namespace Webflow.Domain.Users
{
    /// <summary>
    /// Класс, представляющий пользователя приложения, наследуемый от IdentityUser
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public required string FirstName { get; set; }

        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        public required string LastName { get; set; }

        /// <summary>
        /// Отчество пользователя
        /// </summary>
        public string? MiddleName { get; set; }
    }
}
