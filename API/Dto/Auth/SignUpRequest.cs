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
    }
}