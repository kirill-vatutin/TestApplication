using FluentValidation;
using TestApplication.Application.Validation;
using TestApplication.Domain.Shared;

namespace TestApplication.Application.Items.UpdateMainInfo;

public class UpdateMainInfoValidator : AbstractValidator<UpdateMainInfoRequest>
{
    public UpdateMainInfoValidator()
    {
        RuleFor(i => i.Id).NotEmpty().WithError(Errors.General.ValueIsRequired());

        RuleFor(i => i.Dto.Name)
            .Must(n => string.IsNullOrWhiteSpace(n) || n.Length < Constants.MAX_LOW_LENGTH)
            .WithMessage("Имя должно быть короче {ComparisonValue} символов.");

        RuleFor(i => i.Dto.Description)
            .Must(n => string.IsNullOrWhiteSpace(n) || n.Length < Constants.MAX_LONG_LENGTH)
            .WithMessage("Описание должно быть короче {ComparisonValue} символов.");

        RuleFor(i => i.Dto.Price)
            .NotNull()
            .GreaterThan(0);

        RuleFor(i => i.Dto.Count)
            .NotNull()
            .GreaterThan(0);
    }
}
