using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webflow.API.Dto;
using Webflow.Application.Services.StudentsService.Interfaces;

namespace Webflow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsService  studentsService;
        public StudentsController(IStudentsService studentsService) { 
            this.studentsService = studentsService;
        }
       [HttpGet("{id}")]
        public async Task<ActionResult<StudentViewDto>> getStudentById(Guid id)
        {
            
            if (id == null)
            {
                return BadRequest("Not found with null id");
            }
            var result = await studentsService.getStudentById(id);
            return Ok(result);

        }
    }
}
