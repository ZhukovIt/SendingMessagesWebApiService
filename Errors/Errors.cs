using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendingMessagesService.Errors
{
    public static class Errors
    {
        public static class General
        {
            public static Error NotFound(string entityName, long id) =>
                new Error("record.not.found", $"\"{entityName}\" not found for Id = \"{id}\"");

            public static Error ValueIsInvalid() =>
                new Error("value.is.invalid", "value is required");

            public static Error ValueIsInvalid(string _ErrorMessage) =>
                new Error("value.is.invalid", _ErrorMessage);

            public static Error ValueIsInvalidType<TValue>(TValue _Value) =>
                new Error("value.is.invalid.type", $"value is not {nameof(TValue)} type");
        }
    }
}
