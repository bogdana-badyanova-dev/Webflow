using Webflow.API.Dto.Shared;
using Webflow.API.Dto.Students;
using Webflow.Application.ErrorMessages.Students;
using Webflow.Application.Services.StudentsService.Interfaces;

namespace Webflow.Application.Services.StudentsService.Implementations
{
    public partial class StudentsService : IStudentsService
    {
        public async Task<BaseResponse<StudentViewDto>> GetStudentById(Guid? id, CancellationToken cancellationToken)
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
                IsSuccess = true,
                Data = studentData,
            };
        }
    }
}
   