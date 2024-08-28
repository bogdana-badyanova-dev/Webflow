using Microsoft.AspNetCore.Mvc;
using Webflow.Application.Services.CoursesService.Interfaces;

namespace Webflow.API.Controllers.Courses
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class CoursesController : ControllerBase
    {
        private readonly ICoursesService coursesService;

        public CoursesController(ICoursesService coursesService)
        {
            this.coursesService = coursesService;
        }
    }
}
