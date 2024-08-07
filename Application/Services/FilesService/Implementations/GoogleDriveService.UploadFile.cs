using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Webflow.API.Dto.Shared;
using Webflow.Application.Services.FilesService.Interfaces;
using Webflow.Domain.Files;

namespace Webflow.Application.Services.FilesService.Implementations
{
    public partial class GoogleDriveService : IFilesService
    {
        /// <summary>
        /// Загружает файл в систему
        /// </summary>
        /// <param name="file">Файл для загрузки</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Ответ с идентификатором загруженного файла</returns>
        public async Task<BaseResponse<Guid>> UploadFile(IFormFile file, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<Guid>()
            {
                IsSuccess = false,
                ErrorMessages = new List<string>(),
            };

            var googleApiConfig = configuration.GetSection("GoogleApi").Get<Dictionary<string, string>>();
            var jsonCredentials = JsonConvert.SerializeObject(googleApiConfig);
            var folderId = googleApiConfig["folder_id"];

            GoogleCredential credential;

            using (var uploadStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(jsonCredentials)))
            {
                credential = GoogleCredential.FromStream(uploadStream)
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
            response.Data = await SaveFile(request.ResponseBody.Id, cancellationToken);

            return response;
        }

        private async Task<Guid> SaveFile(string fileId, CancellationToken cancellationToken)
        {
            var importedFile = new UploadedFile
            {
                Id = new Guid(),
                FileId = fileId,
            };

            return await filesRepository.AddAsync(importedFile, cancellationToken);
        }
    }
}