namespace Webflow.Domain.Shared
{
    /// <summary>
    /// Интерфейс, представляющий параметры пагинации для запросов данных
    /// </summary>
    public interface IPagedRequest
    {
        /// <summary>
        /// Номер текущей страницы. Значение должно быть положительным
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Размер страницы, то есть количество элементов на одной странице. Значение должно быть положительным
        /// </summary>
        public int Size { get; set; }
    }

}
