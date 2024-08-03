namespace Webflow.Application.Services.FilesService.Interfaces
{
    public interface IFilesService
    {
        Task<IEnumerable<Domain.Files.File>> GetFiles();
        Task<bool> AddFileAsync(Domain.Files.File file);
        Task<bool> DeleteFileAsync(Guid id);
        Task<Domain.Files.File> GetFileByIdAsync(Guid id);
    }
}
