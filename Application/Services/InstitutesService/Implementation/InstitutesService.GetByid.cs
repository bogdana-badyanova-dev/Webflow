using Webflow.API.Dto.Institutes;
using Webflow.API.Dto.Shared;
using Webflow.Application.Messages.ErrorMessages.Students;
using Webflow.Application.Services.InstitutesService.Interfaces;

namespace Webflow.Application.Services.InstitutesService.Implementation
{
    public partial class InstitutesService : IInstitutesService
    {
        public async Task<BaseResponse<InstituteView>> GetById(Guid? id, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<InstituteView>()
            {
                IsSuccess = false,
                ErrorMessages = new List<string>()
            };

            if (id == null)
            {
                response.ErrorMessages.Append(InstitutesErrorMessages.ID_CANNOT_BE_NULL);
                return response;
            }

            var result = await institutesRepository.GetByIdAsync((Guid)id, cancellationToken);

            if (result == null)
            {
                response.ErrorMessages.Append(InstitutesErrorMessages.INSTITUTE_NOT_FOUND);
                return response;
            }

            var data = mapper.Map<InstituteView>(result);

            response.IsSuccess = true;
            response.Data = data;
            return response;
        }
    }
}
