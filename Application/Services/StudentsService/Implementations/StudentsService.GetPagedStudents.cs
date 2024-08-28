using Webflow.API.Dto.Shared;
using Webflow.API.Dto.Students;
using Webflow.Application.Messages.ErrorMessages.Students;
using Webflow.Application.Services.StudentsService.Interfaces;
using Webflow.Domain.Shared;

namespace Webflow.Application.Services.StudentsService.Implementations
{
    public partial class StudentsService : IStudentsService
    {
        /// <summary>
        /// Получение списка студентов с поддержкой пагинации и сортировки
        /// </summary>
        /// <param name="request">Запрос с параметрами пагинации, фильтрации и сортировки</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Ответ, содержащий список студентов и общую информацию о пагинации</returns>
        public async Task<BaseResponse<PaginatedResponse<StudentView>>> GetPagedStudents(GetPagedStudentsRequest request, CancellationToken cancellationToken)
        {
            var result = await studentsRepository.GetPagedAsync(request, cancellationToken);

            var response = new BaseResponse<PaginatedResponse<StudentView>>()
            {
                IsSuccess = false,
                 ErrorMessages = new List<string>()
            };

            if (result == null)
            {
                response.ErrorMessages.Append(StudentErrorMessages.STUDENTS_NOT_FOUND);
                return response;
            }

            var studentsData = mapper.Map<PaginatedResponse<StudentView>>(result);
            response.IsSuccess = true;
            response.Data = studentsData;
            return response;
        }
    }
}
   