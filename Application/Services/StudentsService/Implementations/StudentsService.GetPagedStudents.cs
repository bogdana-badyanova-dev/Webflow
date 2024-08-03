using Webflow.API.Dto.Shared;
using Webflow.API.Dto.Students;
using Webflow.Application.ErrorMessages.Students;
using Webflow.Application.Services.StudentsService.Interfaces;
using Webflow.Domain.Shared;

namespace Webflow.Application.Services.StudentsService.Implementations
{
    public partial class StudentsService : IStudentsService
    {
        public async Task<BaseResponse<PaginatedResponse<StudentViewDto>>> GetPagedStudents(GetPagedStudentsRequest request, CancellationToken cancellationToken)
        {
            var result = await studentsRepository.GetPagedAsync(request, cancellationToken);

            if (result == null)
            {
                return new BaseResponse<PaginatedResponse<StudentViewDto>>()
                {
                    IsSuccess = false,
                    ErrorMessages = new List<string>([StudentErrorMessages.STUDENTS_NOT_FOUND])
                };
            }

            var studentsData = mapper.Map<PaginatedResponse<StudentViewDto>>(result);

            return new BaseResponse<PaginatedResponse<StudentViewDto>>()
            {
                IsSuccess = true,
                Data = studentsData,
            };
        }
    }
}
   