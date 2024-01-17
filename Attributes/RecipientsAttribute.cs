using CSharpFunctionalExtensions;
using SendingMessagesService.Dtos;
using SendingMessagesService.Logic;
using SendingMessagesService.Errors;
using System.ComponentModel.DataAnnotations;

namespace SendingMessagesService.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RecipientsAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            if (value is not IEnumerable<int> recipients)
                return new ValidationResult(Errors.Errors.General.ValueIsInvalidType(value).Serialize());

            Result<Recipients> recipientsResult = Recipients.Create(recipients);

            if (recipientsResult.IsFailure)
                return new ValidationResult(recipientsResult.Error.Serialize());

            return ValidationResult.Success;
        }
    }
}
