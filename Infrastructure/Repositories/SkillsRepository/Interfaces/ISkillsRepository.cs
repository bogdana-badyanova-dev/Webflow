using Webflow.Domain.Skills;

namespace Webflow.Infrastructure.Repositories.SkillsRepository.Interfaces
{
    public interface ISkillsRepository
    {
        public Task<Skill> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
