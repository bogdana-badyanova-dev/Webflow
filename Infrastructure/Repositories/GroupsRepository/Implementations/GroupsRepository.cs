using Webflow.Domain.Groups;
using Webflow.Infrastructure.Repositories.BaseRepository.Implementations;
using Webflow.Infrastructure.Repositories.GroupsRepository.Interfaces;

namespace Webflow.Infrastructure.Repositories.SkillsRepository.Implementations
{
    public class GroupsRepository : BaseRepository<Group>, IGroupsRepository
    {
        public GroupsRepository(WebflowContext context) : base(context)
        {
        }
    }
}
