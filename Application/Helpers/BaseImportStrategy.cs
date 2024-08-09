using Webflow.Application.Interfaces.Import;
using Webflow.Application.Interfaces;
using Webflow.API.Dto.Import;
using OfficeOpenXml;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static Google.Apis.Requests.BatchRequest;

namespace Webflow.Application.Helpers
{
    public abstract class BaseImportStrategy<T, K> : IImportStrategy<T>
    where T : ImportResult
    where K : class, new()
    {
        public abstract Task<T> Import(Guid fileId, IEnumerable<FieldMapping> mappings, CancellationToken cancellationToken);

        public IEnumerable<K> ConvertFileContentToModelCollection(byte[] content, IEnumerable<FieldMapping> mappings)
        {
            var data = new List<K>();

            using (Stream stream = new MemoryStream(content))
            {
                using (var package = new ExcelPackage(stream))
                {
                    var worksheet = package.Workbook.Worksheets.FirstOrDefault();

                    if (worksheet == null)
                    {
                        throw new Exception();
                    }

                    var modelFields = typeof(InnopolisImport).GetProperties()
                        .Select((prop, index) => new { prop.Name, Index = index })
                        .ToList();

                    var mappingIndexes = new Dictionary<int, List<int>>();

                    for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
                    {
                        var tableField = worksheet.Cells[1, col].Text;
                        var mappingField = mappings.FirstOrDefault(m => m.ColumnName == tableField);

                        if (mappingField == null) continue;

                        var modelField = modelFields.FirstOrDefault(mf => mf.Name == mappingField.ModelField);

                        if (modelField == null) continue;

                        int modelFieldIndex = modelField.Index;

                        if (!mappingIndexes.ContainsKey(modelFieldIndex))
                        {
                            mappingIndexes[modelFieldIndex] = new List<int>();
                        }

                        mappingIndexes[modelFieldIndex].Add(col);
                    }

                    for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                    {
                        var model = new K();

                        foreach (var mapping in mappingIndexes)
                        {
                            int modelFieldIndex = mapping.Key;
                            var columns = mapping.Value;

                            var a = typeof(K).GetProperties();

                            var propertyInfo = a.ElementAt(modelFieldIndex);

                            foreach (var col in columns)
                            {
                                var cellValue = worksheet.Cells[row, col].Text;
                                object value = Convert.ChangeType(cellValue, propertyInfo.PropertyType);
                                propertyInfo.SetValue(model, value);
                            }
                        }

                        data.Add(model);
                    }

                }
            }

            return data;
        }
    }
}
