namespace Webflow.Domain.Shared
{
    /// <summary>
    /// Представляет ответ с результатами пагинации
    /// </summary>
    /// <typeparam name="T">Тип элементов, содержащихся в ответе</typeparam>
    public class PaginatedResponse<T>
    {
        /// <summary>
        /// Список элементов, принадлежащих к текущей странице
        /// </summary>
        public IEnumerable<T> Items { get; set; } = new List<T>();

        /// <summary>
        /// Общее количество элементов в наборе данных, не зависящее от пагинации
        /// </summary>
        public int TotalCount { get; set; } = 0;
    }

}
