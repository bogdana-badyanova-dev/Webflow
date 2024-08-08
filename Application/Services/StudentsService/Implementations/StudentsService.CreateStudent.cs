using Webflow.API.Dto.Shared;
using Webflow.API.Dto.Students;
using Webflow.Application.Messages.ErrorMessages.Students;
using Webflow.Application.Services.StudentsService.Interfaces;
using Webflow.Domain.Students;

namespace Webflow.Application.Services.StudentsService.Implementations
{
    public partial class StudentsService : IStudentsService
    {
        public async Task<BaseResponse<StudentViewDto>> CreateStudent(CreateStudentRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<StudentViewDto>()
            {
                IsSuccess = false,
                ErrorMessages = new List<string>()
            };
            var student = mapper.Map<Student>(request);

            var result = await studentsRepository.AddAsync(student, cancellationToken);

            if (result == Guid.Empty)
            {
                response.ErrorMessages.Append(StudentErrorMessages.STUDENT_CANNOT_CREATE);
                return response;
            }

            response.IsSuccess = true;
            response.Data = mapper.Map<StudentViewDto>(student);
            return response;
        }
    }
}