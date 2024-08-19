using System.Collections;
using System.Reflection;
using Webflow.API.Dto.Import;
using Webflow.Application.Interfaces;
using Webflow.Application.Interfaces.Import;

namespace Webflow.Application.Helpers
{
    public partial class MoodleImportStrategy : BaseImportStrategy<IImportResult, MoodleImport>
    {
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
