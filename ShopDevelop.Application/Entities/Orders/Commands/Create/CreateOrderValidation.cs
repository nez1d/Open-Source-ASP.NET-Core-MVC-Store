using FluentValidation;

namespace ShopDevelop.Application.Entities.Orders.Commands.Create;

public class CreateOrderValidation : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderValidation()
    {
        RuleFor(order => order.Address)
            .MinimumLength(5)
            .MaximumLength(150)
            .NotEmpty()
            .NotNull()
            .WithMessage("");
        
        RuleFor(order => order.Country)
            .MinimumLength(5)
            .MaximumLength(45)
            .NotEmpty()
            .NotNull()
            .WithMessage("");
        
        RuleFor(order => order.City)
            .MinimumLength(5)
            .MaximumLength(50)
            .NotEmpty()
            .NotNull()
            .WithMessage("");
        
        RuleFor(order => order.Amount)
            .NotNull()
            .WithMessage("");
        
        RuleFor(order => order.ProductId)
            .NotNull()
            .NotEqual(Guid.Empty)
            .WithMessage("");
    }
}