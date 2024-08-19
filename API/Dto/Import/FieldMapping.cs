namespace Webflow.API.Dto.Import
{
    /// <summary>
    /// Представляет отображение поля модели на название столбца в файле импорта
    /// </summary>
    public class FieldMapping
    {
        /// <summary>
        /// Имя поля модели, которое будет сопоставлено со столбцом в файле
        /// </summary>
        public string ModelField { get; set; }

        /// <summary>
        /// Название столбца в файле импорта, соответствующее полю модели
        /// </summary>
        public string ColumnName { get; set; }
    }
}
