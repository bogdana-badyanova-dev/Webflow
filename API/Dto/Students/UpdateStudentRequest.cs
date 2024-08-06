using System.ComponentModel;
using Webflow.Application.Enums;

namespace Webflow.API.Dto.Students
{
    /// <summary>
    /// Запрос для Обновления данных о студенте
    /// </summary>
    public class UpdateStudentRequest 
    {
        /// <summary>
        /// Имя студента
        /// </summary>
        [DefaultValue(null)]
        public string? FirstName { get; set; }

        /// <summary>
        /// Фамилия студента
        /// </summary>
        [DefaultValue(null)]
        public string? LastName { get; set; }

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
        [DefaultValue("example@gmail.com")]
        public string? Email { get; set; }

        /// <summary>
        /// Номер телефона студента
        /// </summary>
        [DefaultValue("+77777777777")]
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
