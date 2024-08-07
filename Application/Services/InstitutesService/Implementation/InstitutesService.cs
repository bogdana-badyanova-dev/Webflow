using AutoMapper;
using Webflow.API.Dto.Institutes;
using Webflow.API.Dto.Shared;
using Webflow.Application.Services.InstitutesService.Interfaces;
using Webflow.Infrastructure.Repositories.InstitutesRepository.Interfaces;
using Webflow.Infrastructure.Repositories.StudentsRepository.Interfaces;

namespace Webflow.Application.Services.InstitutesService.Implementation
{
    /// <summary>
    /// Сервис для работы с данными институтов
    /// </summary>
    /// <remarks>
    /// Этот сервис предоставляет методы для получения информации о институтах, используя репозиторий институтов и маппер для преобразования данных
    /// </remarks>
    public partial class InstitutesService : IInstitutesService
    {
        private readonly IInstitutesRepository institutesRepository;
        private readonly IMapper mapper;
        public InstitutesService(IMapper mapper, IInstitutesRepository institutesRepository)
        {
            this.mapper = mapper;
            this.institutesRepository = institutesRepository;
        }
    }
}
