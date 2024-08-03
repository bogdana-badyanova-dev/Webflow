using Webflow.Domain.Shared;

namespace Webflow.API.Dto.Students
{
    /// <summary>
    /// Запрос для получения списка студентов с поддержкой пагинации и сортировки
    /// </summary>
    public class GetPagedStudentsRequest : IPagedRequest, ISortedRequest
    {
        /// <summary>
        /// Имя студента для фильтрации
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Идентификатор группы для фильтрации
        /// </summary>
        public Guid? GroupId { get; set; }

        /// <summary>
        /// Идентификатор института для фильтрации
        /// </summary>
        public Guid? InstituteId { get; set; }

        /// <summary>
        /// Номер страницы для пагинации
        /// </summary>
        public required int Page { get; set; } = 1;

        /// <summary>
        /// Размер страницы для пагинации
        /// </summary>
        public required int Size { get; set; } = 10;

        /// <summary>
        /// Список полей для сортировки и направление сортировки
        /// </summary>
        public SortField[] Sort { get; set; } = [];
    }

}
