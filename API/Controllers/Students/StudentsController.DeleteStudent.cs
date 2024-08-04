using Microsoft.AspNetCore.Mvc;
using Webflow.API.Dto.Shared;

namespace Webflow.API.Controllers.Students
{
    public partial class StudentsController : ControllerBase
    {

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse<string>>> DeleteStudent(Guid? id, CancellationToken cancellationToken) 
        {
            var result = await studentsService.DeleteStudent(id, cancellationToken);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
