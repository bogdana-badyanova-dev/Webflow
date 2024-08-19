using Webflow.API.Dto.Import;
using Webflow.Application.Interfaces;
using Webflow.Application.Services.FilesService.Interfaces;

namespace Webflow.Application.Helpers
{
    /// <summary>
    /// Стратегия импорта данных из Moodle, основанная на содержимом Excel файлов.
    /// </summary>
    /// <remarks>
    /// Этот класс отвечает за загрузку и преобразование данных из файлов, полученных из платформы Moodle, в модель <see cref="MoodleImport"/>.
    /// </remarks>
    public partial class MoodleImportStrategy : BaseImportStrategy<IImportResult, MoodleImport>
    {
        private readonly IFilesService filesService;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="MoodleImportStrategy"/> с указанным сервисом файлов.
        /// </summary>
        /// <param name="filesService">Сервис для загрузки файлов.</param>
        public MoodleImportStrategy(IFilesService filesService)
        {
            this.filesService = filesService;
        }
    }
}
