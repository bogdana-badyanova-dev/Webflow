using Webflow.Application.Interfaces.Import;
using Webflow.Application.Interfaces;
using Webflow.API.Dto.Import;
using Webflow.Application.Services.FilesService.Interfaces;
using OfficeOpenXml;

namespace Webflow.Application.Helpers
{
    // TODO Вынести 
    public class InnopolisImportResult : ImportResult
    {
        public IEnumerable<InnopolisImport> Data { get; set; }
    }

    public class InnopolisImportStrategy : IImportStrategy<ImportResult>
    {
        // private readonly IFilesRepository filesRepository;
        private readonly IFilesService filesService;

        public InnopolisImportStrategy(IFilesService filesService)
        {
            // this.filesRepository = filesRepository;
            this.filesService = filesService;
        }

        public async Task<ImportResult> Import(Guid fileId, IEnumerable<FieldMapping> mappings, CancellationToken cancellationToken)
        {
            var file = await filesService.DownloadFile(fileId, cancellationToken);
            var response = new InnopolisImportResult
            {
                FileId = fileId
            };
            var data = new List<InnopolisImport>();

            // TODo проверить Data
            using (Stream stream = new MemoryStream(file.Data.Content))
            {
                using (var package = new ExcelPackage(stream))
                {
                    var worksheet = package.Workbook.Worksheets.FirstOrDefault();
                    if (worksheet == null)
                    {
                        throw new Exception();
                    }

                    // маппинг (столбец (начало с 1) - модель (начало с 0))
                    // 1 столбец ФИО -> email [1, 1]
                    // 2 столбец EMAIL -> FIO [2, 0]
                    // 3 столбец КУРС -> CourseName [3,2]

                    var modelFields = typeof(InnopolisImport).GetProperties()
                        .Select((prop, index) => new { Name = prop.Name, Index = index })
                        .ToList();

                    // Индекс поля в модели \ индексы столбцов
                    var mappingIndexes = new Dictionary<int, List<int>>();

                    for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
                    {
                        // Случай если поле модели это не массив
                        var tableField = worksheet.Cells[1, col].Text;
                        var mappingField = mappings.FirstOrDefault(m => m.ColumnName == tableField);

                        if (mappingField == null) continue;

                        var modelField = modelFields.FirstOrDefault(mf => mf.Name == mappingField.ModelField);

                        if (modelField == null) continue;

                        int modelFieldIndex = modelField.Index;

                        // Проверяем, есть ли уже запись для этого поля в модели
                        if (!mappingIndexes.ContainsKey(modelFieldIndex))
                        {
                            mappingIndexes[modelFieldIndex] = new List<int>();
                        }

                        // Добавляем индекс колонки Excel в список для этого поля
                        mappingIndexes[modelFieldIndex].Add(col);
                    }

                    for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                    {
                        var model = new InnopolisImport();

                        foreach (var mapping in mappingIndexes)
                        {
                            int modelFieldIndex = mapping.Key; // Индекс поля в модели
                            var columns = mapping.Value; // Список индексов колонок

                            // Получаем свойство модели по индексу
                            var propertyInfo = typeof(InnopolisImport).GetProperties().ElementAt(modelFieldIndex);

                            // Получаем значения для свойства из указанных колонок
                            foreach (var col in columns)
                            {
                                var cellValue = worksheet.Cells[row, col].Text;

                                // Преобразуем значение в тип свойства модели
                                object value = Convert.ChangeType(cellValue, propertyInfo.PropertyType);

                                // Устанавливаем значение свойства модели
                                propertyInfo.SetValue(model, value);
                            }
                        }

                        // Добавляем заполненную модель в список данных
                        data.Add(model);
                    }

                }
            }

            response.Data = data;
            return response;
        }
    }
}
