using CSharpFunctionalExtensions;
using SendingMessagesService.Dtos;
using SendingMessagesService.Logic;
using SendingMessagesService.Errors;
using System.ComponentModel.DataAnnotations;

namespace SendingMessagesService.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class BodyAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            if (value is not string body)
                return new ValidationResult(Errors.Errors.General.ValueIsInvalidType(value).Serialize());

            Result<Body> bodyResult = Body.Create(body);

            if (bodyResult.IsFailure)
                return new ValidationResult(bodyResult.Error.Serialize());

            return ValidationResult.Success;
        }
    }
}
