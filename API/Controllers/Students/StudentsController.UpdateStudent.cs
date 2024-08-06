using Microsoft.AspNetCore.Mvc;
using Webflow.API.Dto.Shared;
using Webflow.API.Dto.Students;

namespace Webflow.API.Controllers.Students
{
    public partial class StudentsController : ControllerBase
    {
        /// <summary>
        /// Обновление данных о студенте
        /// </summary>
        /// <param name="request">Запрос с данными для создания студента</param>
        /// <param name="cancellationToken">Токен для отмены операции</param>
        /// <returns>Ответ, содержащий результат операции создания студента</returns>
        /// <response code="200">Успешный ответ с результатом создания студента</response>
        /// <response code="400">Ошибка при обработке запроса, например, неверные данные</response>
        [HttpPut("{id}")]
        public async Task<ActionResult<BaseResponse<string>>> UpdateStudent([FromRoute] Guid? id, UpdateStudentRequest request, CancellationToken cancellationToken) 
        {
            var result = await studentsService.UpdateStudent(id, request, cancellationToken);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
