using System.ComponentModel;

namespace Webflow.API.Dto.Auth
{
    /// <summary>
    /// Класс, представляющий запрос на вход в систему
    /// </summary>
    public class SignInRequest
    {
        /// <summary>
        /// Адрес электронной почты пользователя
        /// </summary>
        [DefaultValue("example@gmail.com")]
        public required string Email { get; set; }

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        [DefaultValue("Qwerty123!")]
        public required string Password { get; set; }
    }

}
