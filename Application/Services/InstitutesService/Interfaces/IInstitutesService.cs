using Webflow.API.Dto.Institutes;
using Webflow.API.Dto.Shared;
using Webflow.Domain.Shared;

namespace Webflow.Application.Services.InstitutesService.Interfaces
{
    /// <summary>
    /// Интерфейс для сервиса управления институтами
    /// Предоставляет методы для выполнения операций над данными институтов
    /// </summary>
    public interface IInstitutesService
    {
        public Task<BaseResponse<InstituteView>> Create(CreateInstituteRequest request,CancellationToken cancellationToken);
        public Task<BaseResponse<InstituteView>> GetById(Guid? id,CancellationToken cancellationToken);
        public Task<BaseResponse<string>> Delete(Guid? id, CancellationToken cancellationToken);

        /// <summary>
        /// Получает постраничный список институтов по запросу.
        /// </summary>
        /// <param name="request">Запрос, содержащий параметры пагинации и фильтрации.</param>
        /// <param name="cancellationToken">Токен отмены для прерывания операции.</param>
        /// <returns>Возвращает объект ответа с постраничным списком институтов, если запрос успешен. В противном случае возвращает ошибку.</returns>
        /// <response code="200">Возвращает постраничный список институтов.</response>
        /// <response code="400">Возвращает ошибку, если запрос содержит некорректные параметры.</response>
        public Task<BaseResponse<PaginatedResponse<InstituteView>>> GetPaged(GetPagedInstitutesRequest request, CancellationToken cancellationToken);
    }
}
