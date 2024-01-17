using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using SendingMessagesService.Errors;
using CSharpFunctionalExtensions;

namespace SendingMessagesService.Utils
{
    public class ModelStateValidator
    {
        public static IActionResult ValidateModelState(ActionContext context)
        {
            (string fieldName, ModelStateEntry entry) = context.ModelState
                .First(x => x.Value.Errors.Count > 0);
            string errorSerialized = entry.Errors.First().ErrorMessage;

            Result<Error> errorResult = Error.TryDeserialize(errorSerialized);
            Error error;
            if (errorResult.IsFailure)
                error = new Error("value.is.invalid", errorSerialized);
            else
                error = errorResult.Value;

            Envelope envelope = Envelope.Error(error, fieldName);
            var result = new BadRequestObjectResult(envelope);

            return result;
        }
    }
}
