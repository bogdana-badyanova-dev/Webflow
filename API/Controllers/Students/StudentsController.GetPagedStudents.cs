using Microsoft.AspNetCore.Mvc;
using Webflow.API.Dto.Shared;
using Webflow.API.Dto.Students;
using Webflow.Domain.Shared;

namespace Webflow.API.Controllers.Students
{
    public partial class StudentsController : ControllerBase
    {
        /// <summary>
        /// Получает список студентов с поддержкой пагинации и сортировки
        /// </summary>
        /// <param name="request">Запрос для получения студентов с параметрами пагинации и сортировки</param>
        /// <param name="cancellationToken">Токен для отмены операции</param>
        /// <returns>Ответ с пагинированными данными о студентах</returns>
        /// <response code="200">Успешный ответ с данными о студентах</response>
        /// <response code="400">Ошибка при обработке запроса, например, неверные параметры</response>
        [HttpPost("paged-students")]
        public async Task<ActionResult<BaseResponse<PaginatedResponse<StudentViewDto>>>> GetPagedStudent([FromBody] GetPagedStudentsRequest request, CancellationToken cancellationToken)
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
