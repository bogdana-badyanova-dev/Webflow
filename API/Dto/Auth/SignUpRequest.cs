using System.ComponentModel;

namespace Webflow.API.Dto.Auth
{
    /// <summary>
    /// Класс, представляющий запрос на регистрацию нового пользователя
    /// </summary>
    public class SignUpRequest
    {
        /// <summary>
        /// Адрес электронной почты нового пользователя
        /// </summary>
        [DefaultValue("example@gmail.com")]
        public required string Email { get; set; }

        /// <summary>
        /// Пароль нового пользователя
        /// </summary>
        [DefaultValue("Qwerty123!")]
        public required string Password { get; set; }

        /// <summary>
        /// Имя нового пользователя
        /// </summary>
        [DefaultValue("Авраам")]
        public required string FirstName { get; set; }

        /// <summary>
        /// Фамилия нового пользователя
        /// </summary>
        [DefaultValue("Линкольн")]
        public required string LastName { get; set; }

        /// <summary>
        /// Отчество нового пользователя
        /// </summary>
        [DefaultValue(null)]
        public string? MiddleName { get; set; }
    }
}