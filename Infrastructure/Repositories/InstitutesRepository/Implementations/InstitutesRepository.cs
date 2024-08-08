using Webflow.Domain.Institutes;
using Webflow.Infrastructure.Repositories.BaseRepository.Implementations;
using Webflow.Infrastructure.Repositories.InstitutesRepository.Interfaces;

namespace Webflow.Infrastructure.Repositories.InstitutesRepository.Implementations
{
    public class InstitutesRepository : BaseRepository<Institute>, IInstitutesRepository
    {
        public InstitutesRepository(WebflowContext context) : base(context)
        {
        }
    }
}
