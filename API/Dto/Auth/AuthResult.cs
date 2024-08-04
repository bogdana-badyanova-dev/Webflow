namespace Webflow.API.Dto.Auth
{
    /// <summary>
    /// Класс, представляющий результат аутентификации пользователя
    /// </summary>
    public class AuthResult
    {
        /// <summary>
        /// Токен доступа, выданный после успешной аутентификации
        /// </summary>
        public required string Token { get; set; }

        /// <summary>
        /// Дата и время истечения срока действия токена
        /// </summary>
        public required DateTime ExpiryDate { get; set; }

        /// <summary>
        /// Тип токена
        /// </summary>
        public required string TokenType { get; set; }
    }

}
