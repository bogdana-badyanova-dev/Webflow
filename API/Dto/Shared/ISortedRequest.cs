using Webflow.Application.Interfaces;

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
        public ISortField[] Sort { get; set; }
    }

}
