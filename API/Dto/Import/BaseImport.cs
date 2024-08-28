namespace Webflow.API.Dto.Import
{
    /// <summary>
    /// Абстрактный класс для передачи данных импорта, содержащий общие свойства для обработки данных студентов и курсов
    /// </summary>
    public abstract class BaseImport
    {
        /// <summary>
        /// ФИО студента
        /// </summary>
        public string FIO { get; set; }

        /// <summary>
        /// Электронная почта студента
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Название курса, к которому относится студент
        /// </summary>
        public string CourseName { get; set; }
    }

}
