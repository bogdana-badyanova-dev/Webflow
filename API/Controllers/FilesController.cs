using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Webflow.Application.Services.FilesService.Interfaces;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;
using Google.Apis.Drive.v3.Data;

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
        public async Task<ActionResult<string>> FileUpload(string filePath)
        {
            filePath = @"C:\Users\timur\Desktop\memy\1.jpg";
            var googleApiConfig = configuration.GetSection("GoogleApi").Get<Dictionary<string, string>>();
            string jsonCredentials = JsonConvert.SerializeObject(googleApiConfig);
            var folderId = googleApiConfig["folder_id"];

            GoogleCredential credential;
            using (var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(jsonCredentials)))
            {
                credential = GoogleCredential.FromStream(stream)
                    .CreateScoped(DriveService.Scope.Drive);
            }

            // Create Drive API service.
            var service = new DriveService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = "Drive API Snippets"
            });

            // Upload file on drive.
            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = Path.GetFileName(filePath),
                Parents = new List<string> { folderId } // Указание родительской папки
            };

            FilesResource.CreateMediaUpload request;
            // Create a new file on drive.
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                // Create a new file, with metadata and stream.
                request = service.Files.Create(fileMetadata, stream, "image/jpeg");
                request.Fields = "id";
                await request.UploadAsync();
            }

            var file = request.ResponseBody;

            return Ok(file.Id);
        }
    }
}
