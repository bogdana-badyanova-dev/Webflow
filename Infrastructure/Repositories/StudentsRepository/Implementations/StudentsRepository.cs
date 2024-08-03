using Webflow.Application.Services.StudentsService.Interfaces;
using Webflow.Domain.Students;
using Webflow.Infrastructure.Repositories.BaseRepository.Implementations;
using Webflow.Infrastructure.Repositories.StudentsRepository.Interfaces;

namespace Webflow.Infrastructure.Repositories.StudentsRepository.Implementations
{
    public class StudentsRepository : BaseRepository<Student>, IStudentsRepository
    {
        public StudentsRepository(WebflowContext context) : base(context)
        {
        }
    }
}
