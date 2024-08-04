using Webflow.API.Dto.Shared;
using Webflow.Application.Messages.ErrorMessages.Students;
using Webflow.Application.Messages.SuccessefulMessages.Students;
using Webflow.Application.Services.StudentsService.Interfaces;

namespace Webflow.Application.Services.StudentsService.Implementations
{
    public partial class StudentsService : IStudentsService
    {
        public async Task<BaseResponse<string>> SoftDeleteStudent(Guid? id, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<string>() {
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
            student.RemovedAt = DateTime.UtcNow;

            var result = await studentsRepository.UpdateAsync(student, cancellationToken);

            if (result == null)
            {
                response.ErrorMessages.Append(StudentErrorMessages.STUDENT_CANNOT_DELETE);
                return response;
            }

            response.IsSuccess = true;
            response.Data = StudentSuccessfulMessages.STUDENT_DELETED;
            return response;
        }
    }
}
   