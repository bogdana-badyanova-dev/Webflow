using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Newtonsoft.Json;
using Webflow.API.Dto.Shared;
using Webflow.Application.Interfaces;
using Webflow.Application.Services.FilesService.Interfaces;

namespace Webflow.Application.Services.FilesService.Implementations
{
    public partial class GoogleDriveService: IFilesService
    {
        public async Task<BaseResponse<FileResult>> DownloadFile(Guid fileId, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<FileResult>()
            {
                IsSuccess = false,
                ErrorMessages = new List<string>(),
            };

            var dbFile = await filesRepository.GetByIdAsync(fileId, cancellationToken);

            if (dbFile == null)
            {
                // TODO
                response.ErrorMessages.Append("Файл не найден");
                return response;
            }

            var googleDriveFileId = dbFile.FileId;

            var googleApiConfig = configuration.GetSection("GoogleApi").Get<Dictionary<string, string>>();
            var jsonCredentials = JsonConvert.SerializeObject(googleApiConfig);

            GoogleCredential credential;
            using (var downloadStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(jsonCredentials)))
            {
                credential = GoogleCredential.FromStream(downloadStream)
                    .CreateScoped(DriveService.Scope.Drive);
            }

            var service = new DriveService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = "Drive API Snippets"
            });

            var request = service.Files.Get(googleDriveFileId);
            var stream = new MemoryStream();

            await request.DownloadAsync(stream, cancellationToken);

            stream.Position = 0;

            var fileDownloadResult = new FileResult
            {
                FileName = request.Execute().Name,
                ContentType = request.Execute().MimeType,
                Content = stream.ToArray()
            };

            response.Data = fileDownloadResult;
            response.IsSuccess = true;


            return response;
        }
    }
}