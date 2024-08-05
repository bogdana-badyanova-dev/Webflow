using Webflow.API.Dto.Shared;
using Webflow.API.Dto.Students;
using Webflow.Domain.Shared;

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
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Возвращает объект <see cref="BaseResponse{StudentViewDto}"/>, содержащий информацию о студенте или сообщения об ошибках</returns>
        public Task<BaseResponse<StudentViewDto>> GetStudentById(Guid? id, CancellationToken cancellationToken);

        /// <summary>
        /// Получение списка студентов с поддержкой пагинации и сортировки
        /// </summary>
        /// <param name="request">Запрос с параметрами пагинации, фильтрации и сортировки</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Ответ, содержащий список студентов и общую информацию о пагинации</returns>
        public Task<BaseResponse<PaginatedResponse<StudentViewDto>>> GetPagedStudents(GetPagedStudentsRequest request, CancellationToken cancellationToken);

        /// <summary>
        /// Удаление студента по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор студента</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Ответ, содержащий результат операции удаления</returns>
        public Task<BaseResponse<string>> DeleteStudent(Guid? id, CancellationToken cancellationToken);

        /// <summary>
        /// Мягкое удаление студента по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор студента</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Ответ, содержащий результат операции удаления</returns>
        public Task<BaseResponse<string>> SoftDeleteStudent(Guid? id, CancellationToken cancellationToken);

        /// <summary>
        /// Создание студента
        /// </summary>
        /// <param name="id">Идентификатор студента</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Ответ, содержащий результат операции удаления</returns>
        public Task<BaseResponse<StudentViewDto>> CreateStudent(CreateStudentRequest request, CancellationToken cancellationToken);

        /// <summary>
        /// обновление студента по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор студента</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Ответ, содержащий результат операции удаления</returns>
        public Task<BaseResponse<StudentViewDto>> UpdateStudent(Guid? id, UpdateStudentRequest request, CancellationToken cancellationToken);
    }
}
