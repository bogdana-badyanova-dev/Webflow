using Webflow.API.Dto.Shared;
using Webflow.API.Dto.Students;
using Webflow.Application.ErrorMessages.Students;
using Webflow.Application.Services.StudentsService.Interfaces;

namespace Webflow.Application.Services.StudentsService.Implementations
{
    public partial class StudentsService : IStudentsService
    {
        /// <summary>
        /// Получает информацию о студенте по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор студента.</param>
        /// <returns>Возвращает объект ответа с информацией о студенте, если запрос успешен. В противном случае возвращает объект ответа с ошибкой.</returns>
        public async Task<BaseResponse<StudentViewDto>> getStudentById(Guid? id, CancellationToken cancellationToken)
        {
            if (id == null)
            {
                return new BaseResponse<StudentViewDto>
                {
                    IsSuccess = false,
                    ErrorMessages = new List<string>([StudentErrorMessages.ID_CANNOT_BE_NULL])
                };
            }

            var result = await studentsRepository.GetByIdAsync((Guid)id, cancellationToken);

            if (result == null)
            {
                return new BaseResponse<StudentViewDto>()
                {
                    IsSuccess = false,
                    ErrorMessages = new List<string>([StudentErrorMessages.STUDENT_NOT_FOUND])
                };
            }

            var studentData = mapper.Map<StudentViewDto>(result);

            return new BaseResponse<StudentViewDto>()
            {
                IsSuccess = false,
                Data = studentData,
            };
        }
    }
}
   