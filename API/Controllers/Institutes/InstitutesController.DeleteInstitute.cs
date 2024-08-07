using Microsoft.AspNetCore.Mvc;
using Webflow.API.Dto.Institutes;
using Webflow.API.Dto.Shared;

namespace Webflow.API.Controllers.Institutes
{
    public partial class InstitutesController : ControllerBase
    {
        /// <summary>
        /// Удаляет информацию о институте по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор института.</param>
        /// <returns>Возвращает объект ответа с информацией о институте, если запрос успешен. В противном случае возвращает ошибку.</returns>
        /// <response code="200">Возвращает информацию о институте.</response>
        /// <response code="400">Возвращает ошибку, если идентификатор пустой или не найден институт.</response>
        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse<InstituteViewDto>>> DeleteInstitute(Guid? id, CancellationToken cancellationToken)
        {
            var result = await institutesService.DeleteInstitute(id, cancellationToken);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
