using Webflow.API.Dto.Shared;
using Webflow.API.Dto.Skills;

namespace Webflow.Application.Services.SkillsService.Interfaces
{
    public interface ISkillsService
    {
        public Task<BaseResponse<SkillView>> Create(CreateSkillRequest request, CancellationToken cancellationToken);
        public Task<BaseResponse<SkillView>> GetById(Guid? id, CancellationToken cancellationToken);
    }
}
