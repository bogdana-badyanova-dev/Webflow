namespace Webflow.API.Dto.Import
{
    /// <summary>
    /// Представляет импорт данных для Moodle
    /// </summary>
    public class MoodleImport : BaseImport
    {
        /// <summary>
        /// Идентификатор аккаунта в Moodle
        /// </summary>
        public string MoodleAccountId { get; set; }

        /// <summary>
        /// Названия элементов курса
        /// </summary>
        public IEnumerable<string> CourseElementName { get; set; } = new List<string>();

        /// <summary>
        /// Статус завершения элементов курса
        /// </summary>
        public IEnumerable<string> IsComplete { get; set; } = new List<string>();

        /// <summary>
        /// Дата завершения элементов курса
        /// </summary>
        public IEnumerable<string> CompleteDate { get; set; } = new List<string>();
    }
}
