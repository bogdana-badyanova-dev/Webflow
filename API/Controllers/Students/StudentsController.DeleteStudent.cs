using Microsoft.AspNetCore.Mvc;
using Webflow.API.Dto.Shared;

namespace Webflow.API.Controllers.Students
{
    public partial class StudentsController : ControllerBase
    {
        /// <summary>
        /// Удаляет студента по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор студента</param>
        /// <param name="cancellationToken">Токен для отмены операции</param>
        /// <returns>Ответ, содержащий результат операции удаления</returns>
        /// <response code="200">Успешный ответ с результатом удаления</response>
        /// <response code="400">Ошибка при обработке запроса, например, неверный идентификатор</response>
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
