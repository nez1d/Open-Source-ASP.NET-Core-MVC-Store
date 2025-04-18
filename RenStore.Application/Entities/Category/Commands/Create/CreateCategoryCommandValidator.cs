using FluentValidation;

namespace RenStore.Application.Entities.Category.Commands.Create;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(seller => seller.Name)
            .MaximumLength(40)
            .MinimumLength(3)
            .NotEmpty()
            .NotNull()
            .WithMessage("");
        
        RuleFor(seller => seller.Name)
            .MaximumLength(40)
            .MinimumLength(3)
            .NotEmpty()
            .NotNull()
            .WithMessage("");
        
        RuleFor(seller => seller.Description)
            .MinimumLength(10)
            .MaximumLength(250)
            .NotEmpty()
            .NotNull()
            .WithMessage("");
    }
}