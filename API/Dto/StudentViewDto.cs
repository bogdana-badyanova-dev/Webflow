using Webflow.Application.Enums;
using Webflow.Domain.Groups;
using Webflow.Domain.Institutes;
using Webflow.Domain.Shared;

namespace Webflow.API.Dto
{
    /// <summary>
    /// Объект передачи данных студента
    /// </summary>
    public class StudentViewDto : MutableEntity<Guid>
    {
        /// <summary>
        /// Имя студента
        /// </summary>
        public required string FirstName { get; set; }

        /// <summary>
        /// Фамилия студента
        /// </summary>
        public required string LastName { get; set; }

        /// <summary>
        /// Отчество студента
        /// </summary>
        public string? MiddleName { get; set; }

        /// <summary>
        /// Дата рождения студента
        /// </summary>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Электронная почта студента
        /// </summary>
        public required string Email { get; set; }

        /// <summary>
        /// Номер телефона студента
        /// </summary>
        public string? Phone { get; set; }

        /// <summary>
        /// Идентификатор аккаунта студента в Moodle
        /// </summary>
        public string? MoodleAccountId { get; set; }

        /// <summary>
        /// Идентификатор аккаунта студента в Иннополисе
        /// </summary>
        public string? InopolisAccountId { get; set; }

        /// <summary>
        /// Пол студента
        /// </summary>
        public required GenderEnum Gender { get; set; } = GenderEnum.UNDEFINED;

        /// <summary>
        /// Идентификатор группы, к которой относится студент
        /// </summary>
        public Guid? GroupId { get; set; }

        /// <summary>
        /// Группа, к которой относится студент
        /// </summary>
        public Group? Group { get; set; }

        /// <summary>
        /// Идентификатор института, к которому относится студент
        /// </summary>
        public Guid? InstituteId { get; set; }

        /// <summary>
        /// Институт, к которому относится студент
        /// </summary>
        public Institute? Institute { get; set; }
    }

}
