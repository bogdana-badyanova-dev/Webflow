using System.Text.Json.Serialization;

namespace Webflow.Application.Enums
{
    /// <summary>
    /// Перечисление статусов ассесмента
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AssessmentStatusEnum
    {
        /// <summary>
        /// Не определен
        /// </summary>
        UNDEFINED = 0,

        /// <summary>
        /// Начат
        /// </summary>
        STARTED = 1,

        /// <summary>
        /// Зарегистрирован
        /// </summary>
        REGISTERED = 2,

        /// <summary>
        /// Выполнен
        /// </summary>
        COMPLETED = 3
    }
}