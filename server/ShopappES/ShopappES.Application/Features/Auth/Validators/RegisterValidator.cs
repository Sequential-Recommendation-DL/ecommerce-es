namespace Application.Features.Auth.Validators;

using Application.Features.Auth.Commands;
using FluentValidation;
using ShopappES.Application.Features.Auth.Commands;
using ShopappES.Application.Features.Auth.Validators;

public class RegisterValidator : AbstractValidator<LoginValidator>
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
