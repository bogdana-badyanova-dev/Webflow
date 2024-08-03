using Microsoft.AspNetCore.Mvc;
using Webflow.API.Dto.Shared;
using Webflow.API.Dto.Students;
using Webflow.Domain.Shared;

namespace Webflow.API.Controllers.Students
{
    public partial class StudentsController : ControllerBase
    {
        [HttpPost("paged-students")]
        public async Task<ActionResult<BaseResponse<PaginatedResponse<StudentViewDto>>>> GetPagedStudent(GetPagedStudentsRequest request, CancellationToken cancellationToken)
        {
            var result = await studentsService.GetPagedStudents(request, cancellationToken);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
