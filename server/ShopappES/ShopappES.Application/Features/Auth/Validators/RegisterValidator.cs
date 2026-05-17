using FluentValidation;
using ShopappES.Application.Features.Auth.Commands;

namespace ShopappES.Application.Features.Auth.Validators;

public class RegisterValidator : AbstractValidator<RegisterCommand>
{
    public RegisterValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.");

        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("Full name is required.");
    }
}
