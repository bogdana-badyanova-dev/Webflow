using Webflow.Data;
using Webflow.Repositories.BaseRepository.Implementations;
using Webflow.Repositories.FilesRepository.Interfaces;

namespace Webflow.Repositories.FilesRepository.Implementations
{
    public class FilesRepository : BaseRepository<Models.File>, IFilesRepository
    {
        public FilesRepository(WebflowContext context) : base(context)
        {
        }

    }
}
