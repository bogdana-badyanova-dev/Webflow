using Webflow.Domain.Institutes;
using Webflow.Infrastructure.Repositories.BaseRepository.Interfaces;

namespace Webflow.Infrastructure.Repositories.InstitutesRepository.Interfaces
{
    /// <summary>
    /// Интерфейс для репозитория институтов, наследующий базовый репозиторий
    /// </summary>
    public interface IInstitutesRepository : IBaseRepository<Institute>
    {
    }
}
