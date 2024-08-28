using FluentValidation;
using Webflow.API.Dto.Groups;

namespace Webflow.Application.Validators.Groups
{
    public class CreateGroupRequestValidator : AbstractValidator<CreateGroupRequest>
    {
        public CreateGroupRequestValidator()
        {
            RuleFor(request => request.Name).NotNull().NotEmpty().WithMessage("Наименование группы обязательно");
        }
    }
}
