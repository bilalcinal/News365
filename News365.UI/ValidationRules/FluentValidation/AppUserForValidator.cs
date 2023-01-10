
using FluentValidation;
using News365.Entities.Concrete;

namespace News365.UI.ValidationRules.FluentValidation;
public class UserForValidator : AbstractValidator<User>
{
    public UserForValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage("Required field please fill.");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Required field please fill.");
    }
}