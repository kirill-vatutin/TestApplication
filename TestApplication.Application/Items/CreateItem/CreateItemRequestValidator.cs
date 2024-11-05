using FluentValidation;
using Items.CreateItem;
using TestApplication.Application.Validation;
using TestApplication.Domain.Shared;

namespace TestApplication.Application.Items.CreateItem;

public class CreateItemRequestValidator : AbstractValidator<CreateItemRequest>
{
    public CreateItemRequestValidator()
    {
        RuleFor(i => i.Name)
           .NotEmpty()
           .WithError(Errors.General.ValueIsInvalid())
           .MaximumLength(Constants.MAX_LOW_LENGTH)
           .WithError(Errors.General.ValueIsInvalid());

        RuleFor(i => i.Description)
            .MaximumLength(Constants.MAX_LONG_LENGTH).WithError(Errors.General.ValueIsInvalid())
            .WithError(Errors.General.ValueIsInvalid())
            .When(x => !string.IsNullOrWhiteSpace(x.Description));

        RuleFor(i => i.Price)
            .GreaterThan(0)
            .WithError(Error.Validation("item.price.too_low", "Price must be greater than 0"));

        RuleFor(i => i.Count)
            .NotNull()
            .WithError(Errors.General.ValueIsInvalid())
            .GreaterThan(0)
            .WithError(Errors.General.ValueIsInvalid());

        RuleFor(i => i.CategoryId)
            .NotEmpty()
            .WithError(Error.Validation("item.category_id.required", "Category ID is required"));
    }
}
