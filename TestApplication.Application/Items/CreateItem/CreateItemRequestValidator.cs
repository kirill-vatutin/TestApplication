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
            .WithError(Errors.General.ValueIsInvalid());

        RuleFor(i => i.Count)
            .NotNull()
            .WithError(Errors.General.ValueIsInvalid())
            .GreaterThan(0)
            .WithError(Errors.General.ValueIsInvalid());

        RuleFor(i => i.CategoryId)
            .NotEmpty()
            .WithError(Errors.General.ValueIsInvalid());
    }
}
