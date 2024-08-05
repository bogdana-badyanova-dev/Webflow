using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Newtonsoft.Json;
using System.Configuration;
using Webflow.API.Dto.Shared;
using Webflow.Application.Services.FilesService.Interfaces;
using Webflow.Infrastructure.Repositories.FilesRepository.Interfaces;

namespace Webflow.Application.Services.FilesService.Implementations
{
    /// <summary>
    /// Сервис для работы с файлами
    /// </summary>
    public class FilesService : IFilesService
    {
        private readonly IFilesRepository filesRepository;
        private readonly IConfiguration configuration;

        public FilesService(IFilesRepository filesRepository, IConfiguration configuration)
        {
            this.filesRepository = filesRepository;
            this.configuration = configuration;
        }

        public async Task<bool> DeleteFile(Guid id, CancellationToken cancellationToken)
        {
            var file = await filesRepository.GetByIdAsync(id, cancellationToken);
            if (file != null)
            {
                await filesRepository.DeleteAsync(file, cancellationToken);
                return true;
            }
            return false;
        }

        public async Task<Domain.Files.File> GetFileById(Guid id, CancellationToken cancellationToken)
        {
            return await filesRepository.GetByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Загружает файл в систему
        /// </summary>
        /// <param name="file">Файл для загрузки</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Ответ с идентификатором загруженного файла</returns>
        public async Task<BaseResponse<string>> UploadFile(IFormFile file, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<string>()
            {
                IsSuccess = false,
                ErrorMessages = new List<string>(),
            };

            var googleApiConfig = configuration.GetSection("GoogleApi").Get<Dictionary<string, string>>();
            string jsonCredentials = JsonConvert.SerializeObject(googleApiConfig);
            var folderId = googleApiConfig["folder_id"];

            GoogleCredential credential;
            using (var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(jsonCredentials)))
            {
                credential = GoogleCredential.FromStream(stream)
                    .CreateScoped(DriveService.Scope.Drive);
            }

            var service = new DriveService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = "Drive API Snippets"
            });

            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = Path.GetFileName(file.FileName),
                Parents = new List<string> { folderId }
            };

            FilesResource.CreateMediaUpload request;
            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                stream.Position = 0;
                request = service.Files.Create(fileMetadata, stream, file.ContentType);
                request.Fields = "id";
                await request.UploadAsync(cancellationToken);
            }

            if (request.ResponseBody.Id == null)
            {
                response.ErrorMessages.Append("Файл не был загружен");
                return response;
            }

            response.IsSuccess = true;

            return response;
        }
    }
}
