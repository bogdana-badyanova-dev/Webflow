using Webflow.API.Dto.Institutes;
using Webflow.API.Dto.Shared;
using Webflow.Application.Enums;
using Webflow.Application.Messages.ErrorMessages.Students;
using Webflow.Application.Services.InstitutesService.Interfaces;
using Webflow.Application.Validators.Institutes;
using Webflow.Domain.Institutes;

namespace Webflow.Application.Services.InstitutesService.Implementation
{
    public partial class InstitutesService : IInstitutesService
    {
        public async Task<BaseResponse<InstituteView>> Create(CreateInstituteRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<InstituteView>()
            {
                IsSuccess = false,
                ErrorMessages = new List<string>()
            };

            var existingInstitute = await institutesRepository.FindAsync(i => i.Name == request.Name, cancellationToken);

            if (existingInstitute.Any())
            {
                response.ErrorMessages = new List<string>() { InstitutesErrorMessages.INSTITUTE_ALREADY_EXISTS };
                return response;
            }

            var validator = new CreateInstituteRequestValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                response.ErrorMessages = validationResult.Errors.Select(e => e.ErrorMessage);
                return response;
            }

            var institute = mapper.Map<Institute>(request);
            var result = await institutesRepository.AddAsync(institute, cancellationToken);

            if (result == Guid.Empty)
            {
                response.ErrorMessages.Append(InstitutesErrorMessages.INSTITUTE_CANNOT_CREATE);
                return response;
            }

            response.IsSuccess = true;
            response.Data = mapper.Map<InstituteView>(institute);

            var notificationMessage = $"Институт '{institute.Name}' был успешно создан.";
            await notificationService.SendNotificationAsync(NotificationType.Success, notificationMessage);

            return response;
        }
    }
}
