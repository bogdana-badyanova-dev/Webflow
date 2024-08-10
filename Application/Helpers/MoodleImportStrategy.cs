using Webflow.API.Dto.Import;
using Webflow.Application.Interfaces;
using Webflow.Application.Services.FilesService.Interfaces;

namespace Webflow.Application.Helpers
{
    public partial class MoodleImportStrategy : BaseImportStrategy<IImportResult, MoodleImport>
    {
        private readonly IFilesService filesService;
        public MoodleImportStrategy(IFilesService filesService)
        {
            this.filesService = filesService;
        }
    }
}
