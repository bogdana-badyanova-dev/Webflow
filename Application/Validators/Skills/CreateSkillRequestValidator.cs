using FluentValidation;
using Webflow.API.Dto.Skills;

namespace Webflow.Application.Validators.Skills
{
    public class CreateSkillRequestValidator : AbstractValidator<CreateSkillRequest>
    {
        public CreateSkillRequestValidator()
        {
            RuleFor(request => request.Name).NotNull().NotEmpty().WithMessage("Наименование компетенции обязательно");
        }
    }
}
