using AutoMapper;
using Webflow.Domain.Shared;
using Webflow.API.Dto.Groups;
using Webflow.Domain.Groups;

namespace Webflow.Application.Mappings
{
    public class GroupMappingProfile : Profile
    {
        public GroupMappingProfile()
        {
            CreateMap<Group, GroupView>();
            CreateMap<CreateGroupRequest, Group>();
            CreateMap<PaginatedResponse<Group>, PaginatedResponse<GroupView>>();
        }
    }
}
