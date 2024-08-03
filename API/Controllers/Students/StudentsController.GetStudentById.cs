using Microsoft.AspNetCore.Mvc;
using Webflow.API.Dto;
using Webflow.API.Dto.Shared;

namespace Webflow.API.Controllers.Students
{
    public partial class StudentsController : ControllerBase
    {
        /// <summary>
        /// Получает информацию о студенте по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор студента.</param>
        /// <returns>Возвращает объект ответа с информацией о студенте, если запрос успешен. В противном случае возвращает ошибку.</returns>
        /// <response code="200">Возвращает информацию о студенте.</response>
        /// <response code="400">Возвращает ошибку, если идентификатор пустой или не найден студент.</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<StudentViewDto>>> getStudentById(Guid? id, CancellationToken cancellationToken)
        {
            var result = await studentsService.getStudentById(id, cancellationToken);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
