using Webflow.API.Dto.Shared;
using Webflow.API.Dto.Students;

namespace Webflow.Application.Services.StudentsService.Interfaces
{
    /// <summary>
    /// Интерфейс для сервиса управления студентами
    /// Предоставляет методы для выполнения операций над данными студентов
    /// </summary>
    public interface IStudentsService
    {
        /// <summary>
        /// Получает данные студента по уникальному идентификатору
        /// </summary>
        /// <param name="id">Уникальный идентификатор студента. Может быть null</param>
        /// <returns>Возвращает объект <see cref="BaseResponse{StudentViewDto}"/>, содержащий информацию о студенте или сообщения об ошибках</returns>
        public Task<BaseResponse<StudentViewDto>> getStudentById(Guid? id, CancellationToken cancellationToken);
    }
}
