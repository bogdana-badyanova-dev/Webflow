using System.ComponentModel;
using Webflow.Application.Enums;

namespace Webflow.API.Dto.Students
{
    /// <summary>
    /// Запрос для создания студента
    /// </summary>
    public class CreateStudentRequest
    {
        /// <summary>
        /// Имя студента
        /// </summary>
        [DefaultValue("Rumit")]
        public required string FirstName { get; set; }

        /// <summary>
        /// Фамилия студента
        /// </summary>
        [DefaultValue("Valenkoff")]
        public required string LastName { get; set; }

        /// <summary>
        /// Отчество студента
        /// </summary>
        [DefaultValue(null)]
        public string? MiddleName { get; set; }

        /// <summary>
        /// Дата рождения студента
        /// </summary>
        [DefaultValue(null)]
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Электронная почта студента
        /// </summary>
        [DefaultValue("example.tim@gmail.com")]
        public required string Email { get; set; }

        /// <summary>
        /// Номер телефона студента
        /// </summary>
        [DefaultValue("+78788832152")]
        public string? Phone { get; set; }

        /// <summary>
        /// Идентификатор аккаунта студента в Moodle
        /// </summary>
        [DefaultValue(null)]
        public string? MoodleAccountId { get; set; }

        /// <summary>
        /// Идентификатор аккаунта студента в Иннополисе
        /// </summary>
        [DefaultValue(null)]
        public string? InopolisAccountId { get; set; }

        /// <summary>
        /// Пол студента
        /// </summary>
        public required GenderEnum Gender { get; set; } = GenderEnum.UNDEFINED;

        /// <summary>
        /// Идентификатор группы, к которой относится студент
        /// </summary>
        [DefaultValue(null)]
        public Guid? GroupId { get; set; }

        /// <summary>
        /// Идентификатор института, к которому относится студент
        /// </summary>
        [DefaultValue(null)]
        public Guid? InstituteId { get; set; }

    }
}
