using FluentValidation;
using ShopappES.Application.Features.Order.Commands;

namespace ShopappES.Application.Features.Order.Validators;

public class UpdateOrderStatusValidator : AbstractValidator<UpdateOrderStatusCommand>
{
    public UpdateOrderStatusValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Order ID is required.");

        RuleFor(x => x.Status)
            .IsInEnum().WithMessage("Invalid order status.");
    }
}
