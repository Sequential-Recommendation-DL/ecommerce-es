namespace Application.Features.Auth.Validators;

using Application.Features.Auth.Commands;
using FluentValidation;

public class RegisterValidator : AbstractValidator<LoginCommand>
{
    public RegisterValidator()
    {
        RuleFor(x => x.Dto.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");

        RuleFor(x => x.Dto.Password)
            .NotEmpty().WithMessage("Password is required.");
    }
}
