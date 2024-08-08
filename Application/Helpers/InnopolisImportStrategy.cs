using Webflow.Application.Interfaces.Import;
using Webflow.Application.Interfaces;
using Webflow.API.Dto.Import;
using Webflow.Infrastructure.Repositories.FilesRepository.Interfaces;
using Webflow.Application.Services.FilesService.Interfaces;
using OfficeOpenXml;

namespace Webflow.Application.Helpers
{

    public class InnopolisImportResult : ImportResult {
        public IEnumerable<InnopolisImport> Data {get; set;}
    }

    public class InnopolisImportStrategy : IImportStrategy<ImportResult>
    {
        // private readonly IFilesRepository filesRepository;
        private readonly IFilesService filesService;
        
        public InnopolisImportStrategy(IFilesService filesService){
            // this.filesRepository = filesRepository;
             this.filesService = filesService;
        }

        public async Task<ImportResult> Import(Guid fileId, IEnumerable<FieldMapping> mappings, CancellationToken cancellationToken)
        {
            //Переделать через сервис
            // var file = await filesRepository.GetByIdAsync(fileId, cancellationToken);
            //if file == null
            var file = await filesService.DownloadFile(fileId, cancellationToken);
            var ColumnToModelField = new List<List<int>>(); 
            var listOfFieldNames = typeof(InnopolisImport).GetProperties().Select(f => f.Name).ToList();
            var response = new ImportResult {
                        FileId = fileId,
                        // Data = new List<InnopolisImport>()
                    };

            // TODo проверить Data
            using (Stream stream = new MemoryStream(file.Data.Content))
            {
                // await file.CopyToAsync(stream, cancellationToken);
                using (var package = new ExcelPackage(stream))
                {
                    var worksheet = package.Workbook.Worksheets.FirstOrDefault();
                    if (worksheet == null)
                    {
                        throw new Exception();
                    }

                    // маппинг (столбец - модель)
                    // 1 столбец ФИО -> email [0, 1]
                    // 2 столбец EMAIL -> FIO [1, 0]
                    // 3 столбец КУРС -> CourseName [2,2]
                    
                    //var headers = new List<string>();
                    // var previewRows = new List<IDictionary<string, object>>();

                    for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
                    {
                        var list = new List<int>() { col};
                        var columName = worksheet.Cells[1, col].Text;
                        var mapping = mappings.FirstOrDefault(element => element.ColumnName == columName);
                        if (mapping == null) continue;
                        var modelFieldIndex = listOfFieldNames.IndexOf(mapping.ModelField);
                        list.Add(modelFieldIndex); 
                        ColumnToModelField.Add(list);
                        // headers.Add(worksheet.Cells[1, col].Text);
                    }

                    for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                    {
                        for (int col = 1; col <= worksheet.Dimension.End.Column; col++) {
                        
                            var model = new InnopolisImport() {
                                
                            };
                        }

                    }
                }
            }

            return response;

            // из базы взять гугл айди
            // пойти на диск 
            // взять файл
            // валидация мапинга (что бы это не значило)
            //
        }
    }
}
