using Webflow.API.Dto.Groups;
using Webflow.API.Dto.Shared;

namespace Webflow.Application.Services.GroupsService.Interfaces
{
    public interface IGroupsService
    {
        public Task<BaseResponse<GroupView>> Create(CreateGroupRequest request, CancellationToken cancellationToken);
        public Task<BaseResponse<GroupView>> GetById(Guid? id, CancellationToken cancellationToken);
    }
}
