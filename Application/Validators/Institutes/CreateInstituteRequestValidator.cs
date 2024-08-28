using FluentValidation;
using Webflow.API.Dto.Institutes;

namespace Webflow.Application.Validators.Institutes
{
    public class CreateInstituteRequestValidator : AbstractValidator<CreateInstituteRequest>
    {
        public CreateInstituteRequestValidator()
        {
            RuleFor(request => request.Name).NotNull().NotEmpty().WithMessage("Наименование института обязательно");
        }
    }
}
