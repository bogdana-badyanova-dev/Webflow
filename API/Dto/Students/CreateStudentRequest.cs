using System.ComponentModel;

namespace Webflow.API.Dto.Students
{
    /// <summary>
    /// Запрос для создания студента
    /// </summary>
    public class CreateStudentRequest : BaseStudentRequest
    {
        /// <summary>
        /// Имя студента
        /// </summary>
        [DefaultValue("Sasha")]
        new public required string FirstName { get; set; }
        /// <summary>
        /// Фамилия студента
        /// </summary>
        [DefaultValue("Gray")]
        new public required string LastName { get; set; }
        /// <summary>
        /// Электронная почта студента
        /// </summary>
        [DefaultValue("example@gmail.com")]
        new public required string Email { get; set; }

    }
}
