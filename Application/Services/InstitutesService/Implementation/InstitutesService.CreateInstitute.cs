using Webflow.API.Dto.Institutes;
using Webflow.API.Dto.Shared;
using Webflow.API.Dto.Students;
using Webflow.Application.Messages.ErrorMessages.Students;
using Webflow.Application.Messages.SuccessefulMessages.Students;
using Webflow.Application.Services.InstitutesService.Interfaces;
using Webflow.Domain.Institutes;
using Webflow.Domain.Students;

namespace Webflow.Application.Services.InstitutesService.Implementation
{
    public partial class InstitutesService : IInstitutesService
    {
        public async Task<BaseResponse<InstituteViewDto>> CreateInstitute(CreateInstituteRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<InstituteViewDto>()
            {
                IsSuccess = false,
                ErrorMessages = new List<string>()
            };

            var institute = mapper.Map<Institute>(request);
            var result = await institutesRepository.AddAsync(institute, cancellationToken);

            if (result == Guid.Empty) {
                response.ErrorMessages.Append(InstituteErrorMessages.INSTITUTE_CANNOT_CREATE);
                return response;
            }

            response.IsSuccess = true;
            response.Data = mapper.Map<InstituteViewDto>(institute);

            return response;
        }
    }
}
