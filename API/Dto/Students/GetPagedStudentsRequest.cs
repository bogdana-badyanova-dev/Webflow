using Webflow.Domain.Shared;
using System.ComponentModel;
using Webflow.Application.Interfaces;

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
        [DefaultValue(null)]
        public string? Name { get; set; }

        /// <summary>
        /// Идентификатор группы для фильтрации
        /// </summary>
        [DefaultValue(null)]
        public Guid? GroupId { get; set; }

        /// <summary>
        /// Идентификатор института для фильтрации
        /// </summary>
        [DefaultValue(null)]
        public Guid? InstituteId { get; set; }

        /// <summary>
        /// Номер страницы для пагинации
        /// </summary>
        [DefaultValue(1)]
        public required int Page { get; set; } = 1;

        /// <summary>
        /// Размер страницы для пагинации
        /// </summary>
        [DefaultValue(10)]
        public required int Size { get; set; } = 10;

        /// <summary>
        /// Список полей для сортировки и направление сортировки
        /// </summary>
        public ISortField[] Sort { get; set; } = [];
    }

}
