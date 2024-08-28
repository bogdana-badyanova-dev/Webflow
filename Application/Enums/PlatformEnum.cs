using System.Text.Json.Serialization;

namespace Webflow.Application.Enums
{
    /// <summary>
    /// Перечисление поддерживаемых платформ
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PlatformEnum
    {
        /// <summary>
        /// Не определена
        /// </summary>
        UNDEFINED = 0,

        /// <summary>
        /// АНО "Университет Иннополис"
        /// </summary>
        INNOPOLIS = 1,

        /// <summary>
        /// СДО СевГУ
        /// </summary>
        MOODLE = 2,

        /// <summary>
        /// 1С Университет
        /// </summary>
        ONE_C = 3,
    }
}