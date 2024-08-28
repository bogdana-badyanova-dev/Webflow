using AutoMapper;
using Webflow.API.Dto.Skills;
using Webflow.Domain.Shared;
using Webflow.Domain.Skills;

namespace Webflow.Application.Mappings
{
    public class SkillMappingProfile : Profile
    {
        public SkillMappingProfile()
        {
            CreateMap<Skill, SkillView>();
            CreateMap<CreateSkillRequest, Skill>();
            CreateMap<PaginatedResponse<Skill>, PaginatedResponse<SkillView>>();
        }
    }
}
