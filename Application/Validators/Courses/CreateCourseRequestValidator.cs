using FluentValidation;
using Webflow.API.Dto.Courses;

namespace Webflow.Application.Validators.Courses
{
    public class CreateCourseRequestValidator : AbstractValidator<CreateCourseRequest>
    {
        public CreateCourseRequestValidator()
        {
            // TODO Убрать этот бред
            RuleFor(request => request.Name).NotNull().NotEmpty().WithMessage("Наименование результата обязательно");
        }
    }
}
