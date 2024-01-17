using CSharpFunctionalExtensions;
using SendingMessagesService.Dtos;
using SendingMessagesService.Logic;
using SendingMessagesService.Errors;
using System.ComponentModel.DataAnnotations;

namespace SendingMessagesService.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class MessageAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            if (value is not SendMessageDto dto)
                return new ValidationResult(Errors.Errors.General.ValueIsInvalidType(value).Serialize());

            Result<Message> messageResult = Message.Create(dto.Subject, dto.Body, dto.Recipients);

            if (messageResult.IsFailure)
                return new ValidationResult(messageResult.Error.Serialize());

            return ValidationResult.Success;
        }
    }
}
