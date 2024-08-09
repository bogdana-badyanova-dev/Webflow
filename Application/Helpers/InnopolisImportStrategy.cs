using Webflow.Application.Interfaces;
using Webflow.API.Dto.Import;
using Webflow.Application.Services.FilesService.Interfaces;

namespace Webflow.Application.Helpers
{
    public partial class InnopolisImportStrategy : BaseImportStrategy<IImportResult, InnopolisImport>
    {
        private readonly IFilesService filesService;

        public InnopolisImportStrategy(IFilesService filesService)
        {
            this.filesService = filesService;
        }
    }
}
