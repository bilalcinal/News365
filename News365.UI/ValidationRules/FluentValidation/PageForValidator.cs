using FluentValidation;
using News365.Entities.Concrete;

namespace News365.ValidationRules.FluentValidation;
public class PageForValidator : AbstractValidator<Page>
{
    public PageForValidator()
    {
        RuleFor(x => x.FileCodeCenterLeft).NotEmpty().WithMessage("Required field please fill.");
        RuleFor(x => x.FileCodeCenter).NotEmpty().WithMessage("Required field please fill.");
        RuleFor(x => x.FileCodeCenterRight).NotEmpty().WithMessage("Required field please fill.");
    }
}