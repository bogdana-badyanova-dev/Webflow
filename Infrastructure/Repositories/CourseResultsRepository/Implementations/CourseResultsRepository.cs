using Webflow.Domain.CourseResults;
using Webflow.Infrastructure.Repositories.BaseRepository.Implementations;
using Webflow.Infrastructure.Repositories.CourseResultsRepository.Interfaces;

namespace Webflow.Infrastructure.Repositories.CourseResultsRepository.Implementations
{
    public class CourseResultsRepository : BaseRepository<CourseResult>, ICourseResultsRepository
    {
        public CourseResultsRepository(WebflowContext context) : base(context)
        {
        }
    }
}
