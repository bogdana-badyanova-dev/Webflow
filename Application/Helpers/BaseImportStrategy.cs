using Webflow.Application.Interfaces.Import;
using Webflow.Application.Interfaces;
using Webflow.API.Dto.Import;
using OfficeOpenXml;
using System.Collections;
using System.Reflection;

namespace Webflow.Application.Helpers
{
    public abstract class BaseImportStrategy<T, K> : IImportStrategy<T>
    where T : IImportResult
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

                    var modelFields = typeof(K).GetProperties()
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

                        // Получаем информацию о свойстве модели
                        var propertyInfo = typeof(K).GetProperty(modelField.Name);

                        // Проверяем, является ли это поле IEnumerable
                        if (propertyInfo != null && typeof(IEnumerable).IsAssignableFrom(propertyInfo.PropertyType) && propertyInfo.PropertyType != typeof(string))
                        {
                            // Если поле является IEnumerable, добавляем его в mappingIndexes как список столбцов
                            if (!mappingIndexes.ContainsKey(modelFieldIndex))
                            {
                                mappingIndexes[modelFieldIndex] = new List<int>();
                            }

                            mappingIndexes[modelFieldIndex].Add(col);
                        }
                        else
                        {
                            // Если поле не является IEnumerable, добавляем только первый соответствующий столбец
                            if (!mappingIndexes.ContainsKey(modelFieldIndex))
                            {
                                mappingIndexes[modelFieldIndex] = new List<int> { col };
                            }
                        }
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
                                SetPropertyValue(model, propertyInfo, cellValue);
                            }
                        }

                        data.Add(model);
                    }

                }
            }

            return data;
        }


        private void SetPropertyValue(object model, PropertyInfo propertyInfo, string cellValue)
        {
            // Проверяем, является ли поле IEnumerable (но не строкой)
            if (typeof(IEnumerable).IsAssignableFrom(propertyInfo.PropertyType) && propertyInfo.PropertyType != typeof(string))
            {
                // Получаем тип элементов внутри IEnumerable
                var elementType = propertyInfo.PropertyType.GetGenericArguments().FirstOrDefault();

                if (elementType != null)
                {
                    // Создаем экземпляр коллекции
                    var listType = typeof(List<>).MakeGenericType(elementType);
                    var list = (IList)Activator.CreateInstance(listType);

                    // Преобразуем значение ячейки в нужный тип и добавляем в коллекцию
                    object value = Convert.ChangeType(cellValue, elementType);
                    list.Add(value);

                    // Добавляем существующие значения, если они уже есть в модели
                    var existingValue = propertyInfo.GetValue(model) as IList;
                    if (existingValue != null)
                    {
                        foreach (var item in existingValue)
                        {
                            list.Add(item);
                        }
                    }

                    // Устанавливаем заполненную коллекцию в свойство модели
                    propertyInfo.SetValue(model, list);
                }
            }
            else
            {
                // Если поле не является IEnumerable, просто устанавливаем значение
                object value = Convert.ChangeType(cellValue, propertyInfo.PropertyType);
                propertyInfo.SetValue(model, value);
            }
        }
    }
}
