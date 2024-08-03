namespace Webflow.Application.Services.FilesService.Interfaces
{
    public interface IFilesService
    {
        Task<IEnumerable<Domain.Files.File>> GetFiles(CancellationToken cancellationToken);
        Task<bool> AddFileAsync(Domain.Files.File file, CancellationToken cancellationToken);
        Task<bool> DeleteFileAsync(Guid id, CancellationToken cancellationToken);
        Task<Domain.Files.File> GetFileByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
