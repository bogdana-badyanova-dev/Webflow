using Webflow.Application.Interfaces.Import;
using Webflow.Application.Interfaces;
using Webflow.API.Dto.Import;
using OfficeOpenXml;
using System.Collections;
using System.Reflection;

namespace Webflow.Application.Helpers
{
    /// <summary>
    /// Абстрактный класс, представляющий базовую стратегию импорта данных
    /// </summary>
    /// <typeparam name="T">Тип результата импорта, реализующий интерфейс <see cref="IImportResult"/></typeparam>
    /// <typeparam name="K">Тип данных, используемый для обработки импорта, должен быть ссылочным типом и иметь конструктор без параметров</typeparam>
    public abstract class BaseImportStrategy<T, K> : IImportStrategy<T>
    where T : IImportResult
    where K : class, new()
    {
        /// <summary>
        /// Импортирует данные из файла на основе предоставленных настроек и сопоставлений полей
        /// </summary>
        /// <param name="fileId">Идентификатор файла, содержащего данные для импорта</param>
        /// <param name="mappings">Список сопоставлений полей, указывающих, как данные в файле должны быть преобразованы в объекты</param>
        /// <param name="cancellationToken">Токен отмены для отмены операции импорта</param>
        /// <returns>Асинхронная задача, возвращающая результат импорта, который реализует интерфейс <see cref="IImportResult"/></returns>
        public abstract Task<T> Import(Guid fileId, IEnumerable<FieldMapping> mappings, CancellationToken cancellationToken);

        /// <summary>
        /// Преобразует содержимое файла в коллекцию моделей на основе предоставленных сопоставлений полей
        /// </summary>
        /// <param name="content">Содержимое файла в виде массива байтов</param>
        /// <param name="mappings">Список сопоставлений полей, указывающих, как данные в файле должны быть преобразованы в объекты</param>
        /// <returns>Коллекция моделей, представляющих данные из файла.</returns>
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
                        .Select((prop, index) => new
                        {
                            Name = prop.Name.ToLower(),
                            Index = index
                        })
                        .ToList();

                    var mappingIndexes = new Dictionary<int, List<int>>();

                    for (int col = 1; col <= worksheet.Dimension.End.Column+1; col++)
                    {
                        var tableField = worksheet.Cells[1, col].Text.ToLower();
                        var mappingField = mappings.FirstOrDefault(m => m.ColumnName.ToLower() == tableField);

                        if (mappingField == null) continue;

                        var modelField = modelFields.FirstOrDefault(mf => mf.Name.ToLower() == mappingField.ModelField.ToLower());

                        if (modelField == null) continue;

                        int modelFieldIndex = modelField.Index;

                        // Получаем информацию о свойстве модели
                        var propertyInfo = typeof(K).GetProperty(
                            modelField.Name,
                            BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance
                        );

                        // Проверяем, является ли это поле IEnumerable
                        if (propertyInfo != null && typeof(IEnumerable).IsAssignableFrom(propertyInfo.PropertyType))
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

                            var propertyInfo = typeof(K).GetProperties()
                            .FirstOrDefault(p => p.Name.ToLower() == modelFields[modelFieldIndex].Name.ToLower());

                            foreach (var col in columns)
                            {
                                var cellValue = worksheet.Cells[row, col].Text;
                                var header = worksheet.Cells[1, col].Text;
                                SetPropertyValue(model, propertyInfo, cellValue, header);
                            }
                        }

                        data.Add(model);
                    }

                }
            }

            return data;
        }

        /// <summary>
        /// Устанавливает значение свойства модели на основе указанного значения ячейки и имени элемента курса
        /// </summary>
        /// <param name="model">Модель, в которую устанавливается значение</param>
        /// <param name="propertyInfo">Информация о свойстве модели, которое нужно установить</param>
        /// <param name="cellValue">Значение ячейки, которое будет присвоено свойству модели</param>
        /// <param name="courseElementName">Опциональное имя элемента курса для дополнительной контекстной информации</param>
        protected virtual void SetPropertyValue(K model, PropertyInfo propertyInfo, string cellValue, string courseElementName = null)
        {
            bool isEnumerableProperty = propertyInfo != null &&
    typeof(IEnumerable).IsAssignableFrom(propertyInfo.PropertyType) &&
    propertyInfo.PropertyType != typeof(string) &&
    propertyInfo.PropertyType.GetInterfaces()
        .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEnumerable<>));

            if (isEnumerableProperty)
            {
                SetIEnumerablePropertyValue(model, propertyInfo, cellValue, courseElementName);
            }
            else
            {
                SetSimplePropertyValue(model, propertyInfo, cellValue);
            }
        }

        /// <summary>
        /// Устанавливает значение простого свойства модели на основе указанного значения ячейки
        /// </summary>
        /// <param name="model">Модель, в которую устанавливается значение</param>
        /// <param name="propertyInfo">Информация о простом свойстве модели, которое нужно установить</param>
        /// <param name="cellValue">Значение ячейки, которое будет присвоено свойству модели</param>
        protected virtual void SetSimplePropertyValue(K model, PropertyInfo propertyInfo, string cellValue)
        {
            object value = Convert.ChangeType(cellValue, propertyInfo.PropertyType);
            propertyInfo.SetValue(model, value);
        }

        /// <summary>
        /// Устанавливает значение свойства типа <see cref="IEnumerable{T}"/> модели на основе указанного значения ячейки.
        /// </summary>
        /// <param name="model">Модель, в которую устанавливается значение</param>
        /// <param name="propertyInfo">Информация о свойстве модели типа <see cref="IEnumerable{T}"/>, которое нужно установить</param>
        /// <param name="cellValue">Значение ячейки, которое будет преобразовано и присвоено свойству модели</param>
        /// <param name="courseElementName">Необязательное имя элемента курса, которое может использоваться для дополнительной обработки значения (по умолчанию <c>null</c>)</param>
        protected virtual void SetIEnumerablePropertyValue(K model, PropertyInfo propertyInfo, string cellValue, string courseElementName = null)
        {
            var elementType = propertyInfo.PropertyType.GetGenericArguments().FirstOrDefault();

            if (elementType != null)
            {
                var listType = typeof(List<>).MakeGenericType(elementType);
                var list = (IList)Activator.CreateInstance(listType);

                object value = Convert.ChangeType(cellValue, elementType);
                list.Add(value);

                var existingValue = propertyInfo.GetValue(model) as IList;
                if (existingValue != null)
                {
                    foreach (var item in existingValue)
                    {
                        list.Add(item);
                    }
                }

                propertyInfo.SetValue(model, list);
            }
        }
    }
}
