namespace Webflow.Domain.Shared
{
    /// <summary>
    /// Абстрактный класс, представляющий параметры пагинации для запросов данных
    /// </summary>
    public abstract class Pagination
    {
        /// <summary>
        /// Номер текущей страницы. Значение должно быть положительным
        /// </summary>
        public int Page { get; set; } = 1;

        /// <summary>
        /// Размер страницы, то есть количество элементов на одной странице. Значение должно быть положительным
        /// </summary>
        public int Size { get; set; } = 10;
    }

}
