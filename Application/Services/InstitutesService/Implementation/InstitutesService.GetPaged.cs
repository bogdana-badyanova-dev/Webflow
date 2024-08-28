using Webflow.API.Dto.Institutes;
using Webflow.API.Dto.Shared;
using Webflow.Application.Messages.ErrorMessages.Students;
using Webflow.Application.Services.InstitutesService.Interfaces;
using Webflow.Domain.Shared;

namespace Webflow.Application.Services.InstitutesService.Implementation
{
    public partial class InstitutesService : IInstitutesService
    {
        /// <summary>
        /// Получает постраничный список институтов по запросу.
        /// </summary>
        /// <param name="request">Запрос, содержащий параметры пагинации и фильтрации.</param>
        /// <param name="cancellationToken">Токен отмены для прерывания операции.</param>
        /// <returns>Возвращает объект ответа с постраничным списком институтов, если запрос успешен. В противном случае возвращает ошибку.</returns>
        /// <response code="200">Возвращает постраничный список институтов.</response>
        /// <response code="400">Возвращает ошибку, если запрос содержит некорректные параметры.</response>
        public async Task<BaseResponse<PaginatedResponse<InstituteView>>> GetPaged(GetPagedInstitutesRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<PaginatedResponse<InstituteView>>()
            {
                IsSuccess = false,
                ErrorMessages = new List<string>()
            };

            var result = await institutesRepository.GetPagedAsync(request, cancellationToken);

            if (result == null)
            {
                response.ErrorMessages.Append(InstitutesErrorMessages.INSTITUTES_NOT_FOUND);
                return response;
            }

            var data = mapper.Map<PaginatedResponse<InstituteView>>(result);

            response.IsSuccess = true;
            response.Data = data;
            return response;
        }
    }
}
