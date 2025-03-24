using FluentValidation;

namespace ShopDevelop.Application.Entities.Review.Commands.Create;

public class CreateReviewCommandValidation : AbstractValidator<CreateReviewCommand>
{
    public CreateReviewCommandValidation()
    {
        RuleFor(review => review.Message)
            .MinimumLength(5)
            .MaximumLength(150)
            .NotEmpty()
            .NotNull()
            .WithMessage("");
        
        RuleFor(review => review.Rating)
            .NotNull()
            .WithMessage("");
        
        RuleFor(review => review.ApplicationUserId)
            .NotNull()
            .NotEqual(Guid.Empty)
            .WithMessage("");
        
        RuleFor(review => review.ProductId)
            .NotNull()
            .NotEqual(Guid.Empty)
            .WithMessage("");
    }
}