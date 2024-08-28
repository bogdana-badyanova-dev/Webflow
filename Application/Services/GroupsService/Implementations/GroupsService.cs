using AutoMapper;
using Webflow.API.Dto.Shared;
using Webflow.API.Dto.Groups;
using Webflow.Application.Services.GroupsService.Interfaces;
using Webflow.Application.Validators.Groups;
using Webflow.Domain.Groups;
using Webflow.Infrastructure.Repositories.GroupsRepository.Interfaces;
using Webflow.Application.Messages.ErrorMessages.Groups;

namespace Webflow.Application.Services.GroupsService.Implementations
{
    public class GroupsService: IGroupsService
    {
        private readonly IGroupsRepository groupsRepository;
        private readonly IMapper mapper;

        public GroupsService(IGroupsRepository groupsRepository, IMapper mapper)
        {
            this.groupsRepository = groupsRepository;
            this.mapper = mapper;
        }

        public async Task<BaseResponse<GroupView>> Create(CreateGroupRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<GroupView>()
            {
                IsSuccess = false,
                ErrorMessages = new List<string>()
            };

            var existingGroup = await groupsRepository.FindAsync(i => i.Name == request.Name, cancellationToken);

            if (existingGroup.Any())
            {
                response.ErrorMessages = new List<string>() { GroupsErrorMessages.GROUP_ALREADY_EXISTS };
                return response;
            }

            var validator = new CreateGroupRequestValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                response.ErrorMessages = validationResult.Errors.Select(e => e.ErrorMessage);
                return response;
            }

            var group = mapper.Map<Group>(request);
            var result = await groupsRepository.AddAsync(group, cancellationToken);

            if (result == Guid.Empty)
            {
                response.ErrorMessages.Append(GroupsErrorMessages.GROUP_CANNOT_CREATE);
                return response;
            }

            response.IsSuccess = true;
            response.Data = mapper.Map<GroupView>(group);

            return response;
        }

        public async Task<BaseResponse<GroupView>> GetById(Guid? id, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<GroupView>()
            {
                IsSuccess = false,
                ErrorMessages = new List<string>()
            };

            if (id == null)
            {
                response.ErrorMessages.Append(GroupsErrorMessages.ID_CANNOT_BE_NULL);
                return response;
            }

            var result = await groupsRepository.GetByIdAsync((Guid)id, cancellationToken);

            if (result == null)
            {
                response.ErrorMessages.Append(GroupsErrorMessages.GROUP_NOT_FOUND);
                return response;
            }

            var data = mapper.Map<GroupView>(result);

            response.IsSuccess = true;
            response.Data = data;
            return response;
        }
    }
}
