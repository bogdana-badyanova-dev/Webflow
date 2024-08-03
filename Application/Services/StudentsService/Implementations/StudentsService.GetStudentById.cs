using Webflow.API.Dto;
using Webflow.API.Dto.Shared;
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
                    ErrorMessages = new List<string> { "Идентификатор не может быть пустым" }
                };
            }

            var result = await studentsRepository.GetByIdAsync((Guid)id, cancellationToken);

            if (result == null)
            {
                return new BaseResponse<StudentViewDto>()
                {
                    IsSuccess = false,
                    ErrorMessages = new List<string>()
                    {
                        "Данные о студенте не найдены"
                    }
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
   