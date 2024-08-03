using AutoMapper;
using Webflow.Application.Services.StudentsService.Interfaces;
using Webflow.Infrastructure.Repositories.StudentsRepository.Interfaces;

namespace Webflow.Application.Services.StudentsService.Implementations
{
    /// <summary>
    /// Сервис для работы с данными студентов
    /// </summary>
    /// <remarks>
    /// Этот сервис предоставляет методы для получения информации о студентах, используя репозиторий студентов и маппер для преобразования данных
    /// </remarks>
    public partial class StudentsService : IStudentsService
    {
        private readonly IStudentsRepository studentsRepository;
        private readonly IMapper mapper;

        /// <summary>
        /// Конструктор сервиса студентов
        /// </summary>
        /// <param name="mapper">Маппер для преобразования данных студентов в представления</param>
        /// <param name="studentsRepository">Репозиторий для доступа к данным студентов</param>
        public StudentsService(IMapper mapper, IStudentsRepository studentsRepository)
        {
            this.studentsRepository = studentsRepository;
            this.mapper = mapper;
        }
    }
}
   