using System.ComponentModel;

namespace Webflow.API.Dto.Institutes
{
    /// <summary>
    /// Запрос для создания нового института
    /// </summary>
    public class CreateInstituteRequest
    {
        /// <summary>
        /// Название института
        /// </summary>
        [DefaultValue("Information technology")]
        public required string Name { get; set; }
    }
}
