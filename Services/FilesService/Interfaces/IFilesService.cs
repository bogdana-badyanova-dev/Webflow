namespace Webflow.Services.FilesService.Interfaces
{
    public interface IFilesService
    {
        Task<IEnumerable<Models.File>> GetFiles();
        Task<bool> AddFileAsync(Models.File file);
        Task<bool> DeleteFileAsync(Guid id);
        Task<Models.File> GetFileByIdAsync(Guid id);
    }
}
