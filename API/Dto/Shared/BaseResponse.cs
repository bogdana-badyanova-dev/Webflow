namespace Webflow.API.Dto.Shared
{
    /// <summary>
    /// Базовый класс для всех ответов от API с поддержкой обобщений
    /// </summary>
    /// <typeparam name="T">Тип данных, возвращаемых в ответе</typeparam>
    public class BaseResponse<T>
    {
        /// <summary>
        /// Указывает, был ли запрос успешным
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Данные, возвращаемые в ответе
        /// </summary>
        public T? Data { get; set; }

        /// <summary>
        /// Сообщения об ошибках, если запрос не был успешным
        /// </summary>
        public IEnumerable<string> ErrorMessages { get; set; } = new List<string>();

        /// <summary>
        /// Предупреждающие сообщения, которые могут быть полезны
        /// </summary>
        public IEnumerable<string> WarningMessages { get; set; } = new List<string>();
    }

}
