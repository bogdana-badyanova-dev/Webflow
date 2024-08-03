namespace Webflow.Domain.Shared
{
    /// <summary>
    /// Интерфейс для запроса с параметрами сортировки
    /// </summary>
    public interface ISortedRequest
    {
        /// <summary>
        /// Массив полей и направлений сортировки для запроса
        /// </summary>
        public SortField[] Sort { get; set; }
    }

}
