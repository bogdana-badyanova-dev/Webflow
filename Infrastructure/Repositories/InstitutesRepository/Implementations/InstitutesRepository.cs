using Webflow.Domain.Institutes;
using Webflow.Infrastructure.Repositories.BaseRepository.Implementations;
using Webflow.Infrastructure.Repositories.InstitutesRepository.Interfaces;

namespace Webflow.Infrastructure.Repositories.InstitutesRepository.Implementations
{
    /// <summary>
    /// Репозиторий для работы с сущностями <see cref="Institute"/>.
    /// Наследует базовые методы работы с сущностями от <see cref="BaseRepository{T}"/>.
    /// </summary>
    public class InstitutesRepository : BaseRepository<Institute>, IInstitutesRepository
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="InstitutesRepository"/>.
        /// </summary>
        /// <param name="context">Контекст базы данных для работы с сущностями <see cref="Institute"/>.</param>
        public InstitutesRepository(WebflowContext context) : base(context)
        {
        }
    }
}
