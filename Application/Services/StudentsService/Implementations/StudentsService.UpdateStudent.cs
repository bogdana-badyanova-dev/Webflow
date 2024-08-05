using System.Threading;
using Webflow.API.Dto.Shared;
using Webflow.API.Dto.Students;
using Webflow.Application.Messages.ErrorMessages.Students;
using Webflow.Application.Messages.SuccessefulMessages.Students;
using Webflow.Application.Services.StudentsService.Interfaces;
using Webflow.Domain.Students;

namespace Webflow.Application.Services.StudentsService.Implementations
{
    public partial class StudentsService : IStudentsService
    {
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

            var domainStudent = mapper.Map<Student>(request);

            domainStudent.Id = (Guid)id;


            var result = await studentsRepository.UpdateAsync(domainStudent, cancellationToken);

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
   