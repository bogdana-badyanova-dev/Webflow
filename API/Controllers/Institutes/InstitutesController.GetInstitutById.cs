using Microsoft.AspNetCore.Mvc;
using Webflow.API.Dto.Institutes;
using Webflow.API.Dto.Shared;
using Webflow.Application.Services.InstitutesService.Implementation;

namespace Webflow.API.Controllers.Institutes
{
    public partial class InstitutesController : ControllerBase
    {
        /// <summary>
        /// Получает информацию о институте по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор института.</param>
        /// <returns>Возвращает объект ответа с информацией о институте, если запрос успешен. В противном случае возвращает ошибку.</returns>
        /// <response code="200">Возвращает информацию о институте.</response>
        /// <response code="400">Возвращает ошибку, если идентификатор пустой или не найден институт.</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<InstituteViewDto>>> GetInstituteById(Guid? id, CancellationToken cancellationToken)
        {
            var result = await institutesService.GetInstituteById(id, cancellationToken);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
