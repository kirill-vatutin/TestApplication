using FluentValidation.Results;
using TestApplication.Domain.Shared;

namespace TestApplication.Application.Validation;

public static class ValidationResultExtensions
{
    public static Error ToError(this ValidationResult validationResult)
    {
        var validationError = validationResult.Errors.First();

        var error = Error.Deserialize(validationError.ErrorMessage);

        return error;
    }
}
