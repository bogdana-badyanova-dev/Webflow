using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Webflow.Application.Enums
{
    /// <summary>
    /// Перечисление полов
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum GenderEnum
    {
        /// <summary>
        /// Не определен
        /// </summary>
        [Display(Name = "Не указан")]
        UNDEFINED = 0,

        /// <summary>
        /// Мужской
        /// </summary>
        [Display(Name = "Мужской")]
        MALE = 1,

        /// <summary>
        /// Женский
        /// </summary>
        [Display(Name = "Женский")] 
        FEMALE = 2,
    }
}
