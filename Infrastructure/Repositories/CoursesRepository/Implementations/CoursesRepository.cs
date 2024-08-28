using Webflow.Domain.Cources;
using Webflow.Infrastructure.Repositories.BaseRepository.Implementations;
using Webflow.Infrastructure.Repositories.CoursesRepository.Interfaces;

namespace Webflow.Infrastructure.Repositories.CoursesRepository.Implementations
{
    public class CoursesRepository : BaseRepository<Course>, ICoursesRepository
    {
        public CoursesRepository(WebflowContext context) : base(context)
        {
        }
    }
}
