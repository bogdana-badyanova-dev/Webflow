using AutoMapper;
using Webflow.API.Dto.Institutes;
using Webflow.API.Dto.Shared;
using Webflow.API.Dto.Students;
using Webflow.Application.Messages.ErrorMessages.Students;
using Webflow.Application.Messages.SuccessefulMessages.Students;
using Webflow.Application.Services.InstitutesService.Interfaces;
using Webflow.Infrastructure.Repositories.InstitutesRepository.Implementations;
using Webflow.Infrastructure.Repositories.StudentsRepository.Implementations;

namespace Webflow.Application.Services.InstitutesService.Implementation
{
    public partial class InstitutesService : IInstitutesService
    {
        public async Task<BaseResponse<InstituteViewDto>> GetInstituteById(Guid? id, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<InstituteViewDto>()
            {
                IsSuccess = false,
                ErrorMessages = new List<string>()
            };

            if (id == null)
            {
                response.ErrorMessages.Append(StudentErrorMessages.ID_CANNOT_BE_NULL);
                return response;
            }

            var result = await institutesRepository.GetByIdAsync((Guid)id, cancellationToken);

            if (result == null)
            {
                response.ErrorMessages.Append(InstituteErrorMessages.INSTITUTE_NOT_FOUND);
                return response;
            }

            var InstituteData = mapper.Map<InstituteViewDto>(result);

            response.IsSuccess = true;
            response.Data = InstituteData;
            return response;
        }
    }
}
