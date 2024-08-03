using Webflow.API.Dto;

namespace Webflow.Application.Services.StudentsService.Interfaces
{
    public interface IStudentsService
    {
        public Task<StudentViewDto> getStudentById(Guid id);

    }
}
