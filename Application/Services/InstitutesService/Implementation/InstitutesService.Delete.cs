using Webflow.API.Dto.Shared;
using Webflow.Application.Messages.ErrorMessages.Students;
using Webflow.Application.Messages.SuccessefulMessages.Institutes;
using Webflow.Application.Services.InstitutesService.Interfaces;

namespace Webflow.Application.Services.InstitutesService.Implementation
{
    public partial class InstitutesService : IInstitutesService
    {
        public async Task<BaseResponse<string>> Delete(Guid? id, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<string>()
            {
                IsSuccess = false,
                ErrorMessages = new List<string>()
            };

            if (response.IsSuccess)
            {
                response.ErrorMessages.Append(InstitutesErrorMessages.ID_CANNOT_BE_NULL);
                return response;
            }

            var institute = await institutesRepository.GetByIdAsync((Guid)id, cancellationToken);
            if (institute == null)
            {
                response.ErrorMessages.Append(InstitutesErrorMessages.INSTITUTE_NOT_FOUND);
                return response;
            }

            var result = await institutesRepository.DeleteAsync(institute, cancellationToken);
            if (!result)
            {
                response.ErrorMessages.Append(StudentErrorMessages.STUDENT_CANNOT_DELETE);
                return response;
            }

            response.IsSuccess = true;
            response.Data = InstituteSuccessfulMessages.INSTITUTE_DELETED;
            return response;
        }
    }
}
