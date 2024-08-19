using System.Collections;
using System.Reflection;
using Webflow.API.Dto.Import;
using Webflow.Application.Interfaces;
using Webflow.Application.Interfaces.Import;

namespace Webflow.Application.Helpers
{
    public partial class MoodleImportStrategy : BaseImportStrategy<IImportResult, MoodleImport>
    {
        /// <summary>
        /// Импортирует данные из файла, предоставленного по указанному идентификатору, в соответствии с заданными сопоставлениями полей.
        /// </summary>
        /// <param name="fileId">Идентификатор файла, содержащего данные для импорта.</param>
        /// <param name="mappings">Список сопоставлений полей для преобразования данных из файла в модель.</param>
        /// <param name="cancellationToken">Токен отмены для отмены операции импорта.</param>
        /// <returns>Результат импорта данных в формате <see cref="IImportResult"/>.</returns>
        public override async Task<IImportResult> Import(Guid fileId, IEnumerable<FieldMapping> mappings, CancellationToken cancellationToken = default)
        {
            var file = await filesService.DownloadFile(fileId, cancellationToken);

            var response = new MoodleImportResult
            {
                FileId = fileId
            };

            var data = ConvertFileContentToModelCollection(file.Data.Content, mappings);

            response.Data = data;
            return response;
        }

        /// <summary>
        /// Устанавливает значения для свойства типа <see cref="IEnumerable{T}"/> модели из значения ячейки.
        /// </summary>
        /// <param name="model">Модель, в которую будут установлены значения свойства.</param>
        /// <param name="propertyInfo">Информация о свойстве, которое необходимо установить.</param>
        /// <param name="cellValue">Значение ячейки, которое нужно преобразовать и установить.</param>
        /// <param name="courseElementName">Имя элемента курса, которое может быть использовано для дополнительной логики (опционально).</param>
        protected override void SetIEnumerablePropertyValue(MoodleImport model, PropertyInfo propertyInfo, string cellValue, string courseElementName = null)
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

                if (propertyInfo.Name == nameof(MoodleImport.IsComplete) || propertyInfo.Name == nameof(MoodleImport.CompleteDate))
                {
                    AddToCourseElementName(model, courseElementName);
                }
            }
        }

        /// <summary>
        /// Добавляет значение к списку имен элементов курса в модели MoodleImport.
        /// </summary>
        /// <param name="model">Модель типа <see cref="MoodleImport"/>.</param>
        /// <param name="courseElementName">Имя элемента курса, которое необходимо добавить в список.</param>
        private void AddToCourseElementName(MoodleImport model, string courseElementName)
        {
            if (!string.IsNullOrEmpty(courseElementName))
            {
                var courseElementProperty = typeof(MoodleImport).GetProperty(nameof(MoodleImport.CourseElementName));

                if (courseElementProperty != null)
                {
                    var existingCourseElementNames = courseElementProperty.GetValue(model) as IList<string> ?? new List<string>();

                    existingCourseElementNames.Add(courseElementName);
                    courseElementProperty.SetValue(model, existingCourseElementNames);
                }
            }
        }
    }
}
