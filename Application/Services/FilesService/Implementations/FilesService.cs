using Webflow.Application.Services.FilesService.Interfaces;
using Webflow.Infrastructure.Repositories.FilesRepository.Interfaces;

namespace Webflow.Application.Services.FilesService.Implementations
{
    public class FilesService : IFilesService
    {
        private readonly IFilesRepository _filesRepository;

        public FilesService(IFilesRepository filesRepository)
        {
            _filesRepository = filesRepository;
        }

        public async Task<IEnumerable<Domain.Files.File>> GetFiles(CancellationToken cancellationToken)
        {
            return await _filesRepository.GetAllAsync(cancellationToken);
        }

        public async Task<bool> AddFileAsync(Domain.Files.File file, CancellationToken cancellationToken)
        {
            return await _filesRepository.AddAsync(file, cancellationToken);
        }

        public async Task<bool> DeleteFileAsync(Guid id, CancellationToken cancellationToken)
        {
            var file = await _filesRepository.GetByIdAsync(id, cancellationToken);
            if (file != null)
            {
                await _filesRepository.DeleteAsync(file, cancellationToken);
                return true;
            }
            return false;
        }

        public async Task<Domain.Files.File> GetFileByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _filesRepository.GetByIdAsync(id, cancellationToken);
        }
    }
}
