using AutoMapper;
using Webflow.API.Dto;
using Webflow.Domain.Students;

namespace Webflow.Application.Mappings
{
    /// <summary>
    /// Профиль маппинга для преобразования объектов типа <see cref="Student"/>
    /// Используется для настройки правил маппинга между сущностями и DTO
    /// </summary>
    public class StudentMappingProfile : Profile
    {
        /// <summary>
        /// Конструктор, который инициализирует правила маппинга
        /// </summary>
        public StudentMappingProfile() {
            CreateMap<Student, StudentViewDto>();
        }
    }
}
