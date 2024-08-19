using Webflow.Infrastructure.Repositories.BaseRepository.Implementations;
using Webflow.Infrastructure.Repositories.FilesRepository.Interfaces;

namespace Webflow.Infrastructure.Repositories.FilesRepository.Implementations
{
    public class FilesRepository : BaseRepository<Domain.Files.UploadedFile>, IFilesRepository
    {
        public FilesRepository(WebflowContext context) : base(context)
        {
        }

    }
}
