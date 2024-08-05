using Microsoft.AspNetCore.Mvc;
using Webflow.API.Dto.Shared;

namespace Webflow.API.Controllers.Files
{
    public partial class FilesController : ControllerBase
    {
        /// <summary>
        /// Загружает файл на сервер
        /// </summary>
        /// <param name="file">Файл для загрузки</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Ответ с идентификатором загруженного файла или ошибка</returns>
        [HttpPost("upload")]
        public async Task<ActionResult<BaseResponse<string>>> FileUpload(IFormFile file, CancellationToken cancellationToken)
        {
            var result = await filesService.UploadFile(file, cancellationToken);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
