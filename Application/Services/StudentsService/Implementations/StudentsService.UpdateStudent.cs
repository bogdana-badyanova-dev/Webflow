using Webflow.API.Dto.Shared;
using Webflow.API.Dto.Students;
using Webflow.Application.Messages.ErrorMessages.Students;
using Webflow.Application.Services.StudentsService.Interfaces;

namespace Webflow.Application.Services.StudentsService.Implementations
{
    public partial class StudentsService : IStudentsService
    {
        /// <summary>
        /// обновление студента по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор студента</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Ответ, содержащий результат операции удаления</returns>
        public async Task<BaseResponse<StudentViewDto>> UpdateStudent(Guid? id, UpdateStudentRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<StudentViewDto>() {
                IsSuccess = false,
                ErrorMessages = new List<string>()
            };
           if (id == null)
            {
                response.ErrorMessages.Append(StudentErrorMessages.ID_CANNOT_BE_NULL);
                return response;
            }
            var student = await studentsRepository.GetByIdAsync((Guid)id, cancellationToken);

            if (student == null)
            {
                response.ErrorMessages.Append(StudentErrorMessages.STUDENT_NOT_FOUND);
                return response;
            }

            mapper.Map( request,student);

            student.UpdatedAt = DateTime.UtcNow;

            var result = await studentsRepository.UpdateAsync(student, cancellationToken);

            if (result == null)
            {
                response.ErrorMessages.Append(StudentErrorMessages.STUDENT_CANNOT_UPDATE);
                return response;
            }

            response.IsSuccess = true;
            response.Data = mapper.Map<StudentViewDto>(student);
            return response;
        }
    }
}
   