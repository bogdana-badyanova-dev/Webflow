using System.ComponentModel;

namespace Webflow.API.Dto.Institutes
{
    public class CreateInstituteRequest
    {
        /// <summary>
        /// Название института
        /// </summary>
        [DefaultValue("Information technology")]
        public required string Name { get; set; }
    }
}
