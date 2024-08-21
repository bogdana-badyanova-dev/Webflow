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
        /// <summary>
        /// Создание студента
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Ответ, содержащий результат операции удаления</returns>
        public async Task<BaseResponse<InstituteViewDto>> CreateInstitute(CreateInstituteRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<InstituteViewDto>()
            {
                IsSuccess = false,
                ErrorMessages = new List<string>()
            };

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
                response.ErrorMessages.Append(InstituteErrorMessages.INSTITUTE_CANNOT_CREATE);
                return response;
            }

            response.IsSuccess = true;
            response.Data = mapper.Map<InstituteViewDto>(institute);

            var notificationMessage = $"Институт '{institute.Name}' был успешно создан.";
            await notificationService.SendNotificationAsync(NotificationType.Success, notificationMessage);

            return response;
        }
    }
}
