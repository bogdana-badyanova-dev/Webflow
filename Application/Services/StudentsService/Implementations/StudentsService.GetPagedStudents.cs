using Webflow.API.Dto.Shared;
using Webflow.API.Dto.Students;
using Webflow.Application.Messages.ErrorMessages.Students;
using Webflow.Application.Services.StudentsService.Interfaces;
using Webflow.Domain.Shared;

namespace Webflow.Application.Services.StudentsService.Implementations
{
    public partial class StudentsService : IStudentsService
    {
        public async Task<BaseResponse<PaginatedResponse<StudentViewDto>>> GetPagedStudents(GetPagedStudentsRequest request, CancellationToken cancellationToken)
        {
            var result = await studentsRepository.GetPagedAsync(request, cancellationToken);
            var response = new BaseResponse<PaginatedResponse<StudentViewDto>>()
            {
                IsSuccess = false,
                 ErrorMessages = new List<string>()
            };

            if (result == null)
            {
                response.ErrorMessages.Append(StudentErrorMessages.STUDENTS_NOT_FOUND);
                return response;
            }

            var studentsData = mapper.Map<PaginatedResponse<StudentViewDto>>(result);
            response.IsSuccess = true;
            response.Data = studentsData;
            return response;
        }
    }
}
   