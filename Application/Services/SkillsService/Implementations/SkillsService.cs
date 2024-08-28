using AutoMapper;
using Webflow.API.Dto.Skills;
using Webflow.API.Dto.Shared;
using Webflow.Application.Messages.ErrorMessages.Students;
using Webflow.Application.Services.SkillsService.Interfaces;
using Webflow.Application.Validators.Skills;
using Webflow.Domain.Skills;
using Webflow.Infrastructure.Repositories.SkillsRepository.Interfaces;

namespace Webflow.Application.Services.SkillsService.Implementations
{
    public partial class SkillsService : ISkillsService
    {
        private readonly ISkillsRepository skillsRepository;
        private readonly IMapper mapper;

        public SkillsService(ISkillsRepository skillsRepository, IMapper mapper)
        {
            this.skillsRepository = skillsRepository;
            this.mapper = mapper;
        }

        public async Task<BaseResponse<SkillView>> Create(CreateSkillRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<SkillView>()
            {
                IsSuccess = false,
                ErrorMessages = new List<string>()
            };

            var existingSkill = await skillsRepository.FindAsync(i => i.Name == request.Name, cancellationToken);

            if (existingSkill.Any())
            {
                response.ErrorMessages = new List<string>() { SkillErrorMessages.SKILL_ALREADY_EXISTS };
                return response;
            }

            var validator = new CreateSkillRequestValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                response.ErrorMessages = validationResult.Errors.Select(e => e.ErrorMessage);
                return response;
            }

            var skill = mapper.Map<Skill>(request);
            var result = await skillsRepository.AddAsync(skill, cancellationToken);

            if (result == Guid.Empty)
            {
                response.ErrorMessages.Append(SkillErrorMessages.SKILL_CANNOT_CREATE);
                return response;
            }

            response.IsSuccess = true;
            response.Data = mapper.Map<SkillView>(skill);

            return response;
        }

        public async Task<BaseResponse<SkillView>> GetById(Guid? id, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<SkillView>()
            {
                IsSuccess = false,
                ErrorMessages = new List<string>()
            };

            if (id == null)
            {
                response.ErrorMessages.Append(StudentErrorMessages.ID_CANNOT_BE_NULL);
                return response;
            }

            var result = await skillsRepository.GetByIdAsync((Guid)id, cancellationToken);

            if (result == null)
            {
                response.ErrorMessages.Append(SkillErrorMessages.SKILL_NOT_FOUND);
                return response;
            }

            var data = mapper.Map<SkillView>(result);

            response.IsSuccess = true;
            response.Data = data;
            return response;
        }
    }
}
