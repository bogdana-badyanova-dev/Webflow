using Microsoft.AspNetCore.Mvc;
using Webflow.Application.Services.CourseResultsService.Interfaces;

namespace Webflow.API.Controllers.CourseResults
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class CourseResultsController : ControllerBase
    {
        private readonly ICourseResultsService courseResultsService;

        public CourseResultsController(ICourseResultsService courseResultsService)
        {
            this.courseResultsService = courseResultsService;
        }
    }
}
