using CSharpFunctionalExtensions;
using SendingMessagesService.Dtos;
using SendingMessagesService.Logic;
using SendingMessagesService.Errors;
using System.ComponentModel.DataAnnotations;

namespace SendingMessagesService.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SubjectAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            if (value is not string subject)
                return new ValidationResult(Errors.Errors.General.ValueIsInvalidType(value).Serialize());

            Result<Subject> subjectResult = Subject.Create(subject);

            if (subjectResult.IsFailure)
                return new ValidationResult(subjectResult.Error.Serialize());

            return ValidationResult.Success;
        }
    }
}
