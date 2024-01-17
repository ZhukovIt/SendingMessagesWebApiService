using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendingMessagesService.Logic
{
    public class Subject : ValueObject
    {
        public string Value { get; }

        private Subject(string value)
        {
            Value = value;
        }

        public static Result<Subject> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return Result.Failure<Subject>("Тема сообщения является обязательной!");

            return Result.Success(new Subject(value));
        }

        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            yield return Value;
        }

        public static implicit operator string(Subject subject)
        {
            return subject.Value;
        }

        public static explicit operator Subject(string value)
        {
            return Create(value).Value;
        }
    }
}
