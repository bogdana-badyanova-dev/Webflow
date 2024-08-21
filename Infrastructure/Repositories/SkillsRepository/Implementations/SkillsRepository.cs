using Webflow.Domain.Skills;
using Webflow.Infrastructure.Repositories.BaseRepository.Implementations;
using Webflow.Infrastructure.Repositories.SkillsRepository.Interfaces;

namespace Webflow.Infrastructure.Repositories.SkillsRepository.Implementations
{
    public class SkillsRepository : BaseRepository<Skill>, ISkillsRepository
    {
        public SkillsRepository(WebflowContext context) : base(context)
        {
        }
    }
}
