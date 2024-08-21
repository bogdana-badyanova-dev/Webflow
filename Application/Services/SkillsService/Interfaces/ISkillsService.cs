using Webflow.API.Dto.Shared;
using Webflow.API.Dto.Skills;

namespace Webflow.Application.Services.SkillsService.Interfaces
{
    public interface ISkillsService
    {
        public Task<BaseResponse<SkillViewDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }

}
