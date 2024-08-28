using AutoMapper;
using Webflow.API.Dto.Institutes;
using Webflow.Domain.Institutes;
using Webflow.Domain.Shared;

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
            CreateMap<Institute, InstituteView>();
            CreateMap<CreateInstituteRequest, Institute>();
            CreateMap<PaginatedResponse<Institute>, PaginatedResponse<InstituteView>>();
        }
    }
}
