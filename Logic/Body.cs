using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendingMessagesService.Logic
{
    public class Body : ValueObject
    {
        public string Value { get; }

        private Body(string value)
        {
            Value = value;
        }

        public static Result<Body> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return Result.Failure<Body>("Тело сообщения является обязательным!");

            return Result.Success(new Body(value));
        }

        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            yield return Value;
        }

        public static implicit operator string(Body body)
        {
            return body.Value;
        }

        public static explicit operator Body(string value)
        {
            return Create(value).Value;
        }
    }
}
