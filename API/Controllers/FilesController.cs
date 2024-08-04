using Microsoft.AspNetCore.Mvc;
using Webflow.Application.Services.FilesService.Interfaces;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Newtonsoft.Json;

namespace Webflow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IFilesService filesService;
        private readonly IConfiguration configuration;

        public FilesController(IFilesService filesService, IConfiguration configuration)
        {
            this.filesService = filesService;
            this.configuration = configuration;
        }

        [HttpPost("upload")]
        public async Task<ActionResult<string>> FileUpload(IFormFile file)
        {
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
                stream.Position = 0; // Reset the stream position to the beginning

                request = service.Files.Create(fileMetadata, stream, file.ContentType);
                request.Fields = "id";
                await request.UploadAsync();
            }

            var uploadedFile = request.ResponseBody;

            return Ok(uploadedFile.Id);
        }
    }
}
