using AutoMapper;
using Webflow.API.Dto.Shared;
using Webflow.API.Dto.Skills;
using Webflow.Application.Messages.ErrorMessages.Students;
using Webflow.Application.Services.SkillsService.Interfaces;
using Webflow.Infrastructure.Repositories.SkillsRepository.Interfaces;

namespace Webflow.Application.Services.SkillsService.Implementations
{
    public class SkillsService : ISkillsService
    {
        private readonly ISkillsRepository skillsRepository;
        private readonly IMapper mapper;

        public SkillsService(ISkillsRepository skillsRepository, IMapper mapper)
        {
            this.skillsRepository = skillsRepository;
            this.mapper = mapper;
        }

        public async Task<BaseResponse<SkillViewDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<SkillViewDto>()
            {
                IsSuccess = false,
                ErrorMessages = new List<string>()
            };

            if (id == null)
            {
                response.ErrorMessages.Append(StudentErrorMessages.ID_CANNOT_BE_NULL);
                return response;
            }

            var result = await skillsRepository.GetByIdAsync(id, cancellationToken);

            if (result == null)
            {
                response.ErrorMessages.Append(SkillErrorMessages.SKILL_NOT_FOUND);
                return response;
            }

            var data = mapper.Map<SkillViewDto>(result);

            response.IsSuccess = true;
            response.Data = data;
            return response;
        }
    }

}
