using Webflow.Repositories.FilesRepository.Interfaces;
using Webflow.Services.FilesService.Interfaces;

namespace Webflow.Services.FilesService.Implementations
{
    public class FilesService : IFilesService
    {
        private readonly IFilesRepository _filesRepository;

        public FilesService(IFilesRepository filesRepository)
        {
            _filesRepository = filesRepository;
        }

        public async Task<IEnumerable<Models.File>> GetFiles()
        {
            return await _filesRepository.GetAllAsync();
        }

        public async Task<bool> AddFileAsync(Models.File file)
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

        public async Task<Models.File> GetFileByIdAsync(Guid id)
        {
            return await _filesRepository.GetByIdAsync(id);
        }
    }
}
