using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
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
        [DefaultValue("Sasha")]
        [Required(ErrorMessage = "Имя обязательно для заполнения.")]
        [Display(Name = "Имя студента")]
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия студента
        /// </summary>
        [DefaultValue("Gray")]
        [Required(ErrorMessage = "Фамилия обязательна для заполнения.")]
        public string LastName { get; set; }

        /// <summary>
        /// Отчество студента
        /// </summary>
        [DefaultValue(null)]
        public string? MiddleName { get; set; }

        /// <summary>
        /// Электронная почта студента
        /// </summary>
        [DefaultValue("example@gmail.com")]
        [Required(ErrorMessage = "Email обязателен для заполнения.")]
        [EmailAddress(ErrorMessage = "Недопустимый адрес электронной почты.")]
        public string Email { get; set; }

        /// <summary>
        /// Дата рождения студента
        /// </summary>
        [DefaultValue(null)]
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Номер телефона студента
        /// </summary>
        [DefaultValue("+77777777777")]
        [Phone(ErrorMessage = "Недопустимый номер телефона.")]
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
        [DefaultValue(GenderEnum.MALE)]
        [Required]
        public GenderEnum Gender { get; set; }

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
