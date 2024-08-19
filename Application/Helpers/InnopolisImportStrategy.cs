using Webflow.Application.Interfaces;
using Webflow.API.Dto.Import;
using Webflow.Application.Services.FilesService.Interfaces;

namespace Webflow.Application.Helpers
{
    /// <summary>
    /// Стратегия импорта данных для платформы Иннополис из Excel файлов.
    /// </summary>
    /// <remarks>
    /// Этот класс отвечает за импорт данных из Excel файлов, где данные соответствуют модели <see cref="InnopolisImport"/>. 
    /// Реализует логику преобразования данных из файла в модель <see cref="IImportResult"/> с учетом сопоставлений полей.
    /// </remarks>
    public partial class InnopolisImportStrategy : BaseImportStrategy<IImportResult, InnopolisImport>
    {
        private readonly IFilesService filesService;

        /// <summary>
        /// Конструктор стратегии импорта
        /// </summary>
        /// <param name="filesService">Сервис для работы с файлами</param>
        public InnopolisImportStrategy(IFilesService filesService)
        {
            this.filesService = filesService;
        }
    }
}
