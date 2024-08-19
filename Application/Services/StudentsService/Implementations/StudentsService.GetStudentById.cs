using Webflow.API.Dto.Shared;
using Webflow.API.Dto.Students;
using Webflow.Application.Messages.ErrorMessages.Students;
using Webflow.Application.Services.StudentsService.Interfaces;

namespace Webflow.Application.Services.StudentsService.Implementations
{
    public partial class StudentsService : IStudentsService
    {
        public async Task<BaseResponse<StudentViewDto>> GetStudentById(Guid? id, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<StudentViewDto>()
            {
                IsSuccess = false,
                ErrorMessages = new List<string>()
            };

            if (id == null)
            {
                response.ErrorMessages.Append(StudentErrorMessages.ID_CANNOT_BE_NULL);
                return response;
            }

            var result = await studentsRepository.GetByIdAsync((Guid)id, cancellationToken);

            if (result == null || result.RemovedAt != null)
            {
                response.ErrorMessages.Append(StudentErrorMessages.STUDENT_NOT_FOUND);
                return response;
            }

            var studentData = mapper.Map<StudentViewDto>(result);

            response.IsSuccess = true;
            response.Data = studentData;
            return response;
        }
    }
}
   