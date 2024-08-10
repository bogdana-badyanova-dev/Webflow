using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Newtonsoft.Json;
using Webflow.API.Dto.Shared;
using Webflow.Application.Services.FilesService.Interfaces;

namespace Webflow.Application.Services.FilesService.Implementations
{
    public partial class GoogleDriveService: IFilesService
    {
        // TODO Удалять файл из БД, если удаляем с диска (добавлено, протестировать)
        public async Task<BaseResponse<bool>> DeleteFile(Guid fileId, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>
            {
                IsSuccess = false,
                ErrorMessages = new List<string>(),
                Data = false
            };

            var file = await filesRepository.GetByIdAsync(fileId, cancellationToken);

            if (file == null)
            {
                // TODO Сделать тип для ошибку
                response.ErrorMessages.Append("Файл не найден");
                return response;
            }

            // TODO нештатная ситуация когда в бд файл без id на диске

            var googleDriveFileId = file.FileId;

            var googleApiConfig = configuration.GetSection("GoogleApi").Get<Dictionary<string, string>>();
            var jsonCredentials = JsonConvert.SerializeObject(googleApiConfig);

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

            var request = service.Files.Delete(googleDriveFileId.ToString());
            await request.ExecuteAsync(cancellationToken);

            response.IsSuccess = true;
            response.Data = true;

            await filesRepository.DeleteAsync(file, cancellationToken);

            return response;
        }
    }
}