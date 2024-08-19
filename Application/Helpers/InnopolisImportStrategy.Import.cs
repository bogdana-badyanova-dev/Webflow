using Webflow.Application.Interfaces;
using Webflow.API.Dto.Import;
using Webflow.Application.Interfaces.Import;

namespace Webflow.Application.Helpers
{    
    public partial class InnopolisImportStrategy : BaseImportStrategy<IImportResult, InnopolisImport>
    {
        /// <summary>
        /// Импортирует данные из Excel файла, используя указанный идентификатор файла и сопоставления полей.
        /// </summary>
        /// <param name="fileId">Идентификатор файла для импорта.</param>
        /// <param name="mappings">Коллекция сопоставлений полей для преобразования данных из файла в модель.</param>
        /// <param name="cancellationToken">Токен отмены для отмены операции импорта.</param>
        /// <returns>Объект <see cref="IImportResult"/> с результатами импорта, включая идентификатор файла и преобразованные данные.</returns>
        public override async Task<IImportResult> Import(Guid fileId, IEnumerable<FieldMapping> mappings, CancellationToken cancellationToken = default)
        {
            var file = await filesService.DownloadFile(fileId, cancellationToken);
            var response = new InnopolisImportResult
            {
                FileId = fileId
            };

            var data = ConvertFileContentToModelCollection(file.Data.Content, mappings);

            response.Data = data;
            return response;
        }
    }
}
