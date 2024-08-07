using AutoMapper;
using Webflow.API.Dto.Institutes;
using Webflow.API.Dto.Students;
using Webflow.Domain.Institutes;
using Webflow.Domain.Shared;
using Webflow.Domain.Students;

namespace Webflow.Application.Mappings
{
    /// <summary>
    /// Профиль маппинга для преобразования объектов типа <see cref="Institute"/>
    /// Используется для настройки правил маппинга между сущностями и DTO
    /// </summary>
    public class InstituteMappingProfile : Profile
    {
        /// <summary>
        /// Конструктор, который инициализирует правила маппинга
        /// </summary>
        public InstituteMappingProfile()
        {
            CreateMap<Institute, InstituteViewDto>();
            CreateMap<CreateInstituteRequest, Institute>();
        }
    }
}
