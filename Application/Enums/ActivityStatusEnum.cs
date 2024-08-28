using System.Text.Json.Serialization;

namespace Webflow.Application.Enums
{
    /// <summary>
    /// Перечисление статусов активности
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
     public enum ActivityStatusEnum
    {
        /// <summary>
        /// Не определен
        /// </summary>
        UNDEFINED = 0,

        /// <summary>
        /// Активный
        /// </summary>
        ACTIVE = 1,

        /// <summary>
        /// Отчислен
        /// </summary>
        EXPELLED = 2,
    }
}