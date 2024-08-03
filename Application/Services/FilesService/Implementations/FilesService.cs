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

        public async Task<IEnumerable<Domain.Files.File>> GetFiles()
        {
            return await _filesRepository.GetAllAsync();
        }

        public async Task<bool> AddFileAsync(Domain.Files.File file)
        {
            return await _filesRepository.AddAsync(file);
        }

        public async Task<bool> DeleteFileAsync(Guid id)
        {
            var file = await _filesRepository.GetByIdAsync(id);
            if (file != null)
            {
                await _filesRepository.DeleteAsync(file);
                return true;
            }
            return false;
        }

        public async Task<Domain.Files.File> GetFileByIdAsync(Guid id)
        {
            return await _filesRepository.GetByIdAsync(id);
        }
    }
}
