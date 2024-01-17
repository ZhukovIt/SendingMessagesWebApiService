using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendingMessagesService.Logic
{
    public class Recipients : ValueObject
    {
        private readonly List<int> _value;

        public IReadOnlyList<int> Value => _value.ToList();

        private Recipients(IEnumerable<int> value)
        {
            _value = value.ToList();
        }

        public static Result<Recipients> Create(IEnumerable<int> value)
        {
            if (value == null || value.Count() == 0)
                return Result.Failure<Recipients>("Наличие хотя бы одного получателя обязательно!");

            return Result.Success(new Recipients(value));
        }

        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            foreach (int val in _value)
            {
                yield return val;
            }
        }
    }
}
