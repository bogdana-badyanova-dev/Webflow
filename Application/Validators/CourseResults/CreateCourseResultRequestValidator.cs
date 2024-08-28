using FluentValidation;
using Webflow.API.Dto.CourseResults;

namespace Webflow.Application.Validators.CourseResults
{
    public class CreateCourseResultRequestValidator : AbstractValidator<CreateCourseResultRequest>
    {
        public CreateCourseResultRequestValidator()
        {
            // TODO убрать этот бред
            RuleFor(request => request.Name).NotNull().NotEmpty().WithMessage("Наименование результата обязательно");
        }
    }
}
