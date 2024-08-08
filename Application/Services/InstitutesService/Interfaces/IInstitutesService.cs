using Webflow.API.Dto.Institutes;
using Webflow.API.Dto.Shared;
using Webflow.Domain.Institutes;

namespace Webflow.Application.Services.InstitutesService.Interfaces
{
    /// <summary>
    /// Интерфейс для сервиса управления институтами
    /// Предоставляет методы для выполнения операций над данными институтов
    /// </summary>
    public interface IInstitutesService
    {
        /// <summary>
        /// Создание студента
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Ответ, содержащий результат операции удаления</returns>
        public Task<BaseResponse<InstituteViewDto>> CreateInstitute(CreateInstituteRequest request,CancellationToken cancellationToken);

        /// <summary>
        /// получение института по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор института</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Ответ, содержащий результат операции удаления</returns>
        public Task<BaseResponse<InstituteViewDto>> GetInstituteById(Guid? id,CancellationToken cancellationToken);

        /// <summary>
        /// Удаление института по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор института</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Ответ, содержащий результат операции удаления</returns>
        public Task<BaseResponse<string>> DeleteInstitute(Guid? id,CancellationToken cancellationToken);
    }
}
