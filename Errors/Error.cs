﻿using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendingMessagesService.Errors
{
    public class Error : ValueObject
    {
        private const string _separator = "||";

        public string Code { get; }

        public string Message { get; }

        internal Error(string code, string message)
        {
            Code = code;
            Message = message;
        }

        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            yield return Code;
        }

        public string Serialize()
        {
            return $"{Code}{_separator}{Message}";
        }

        public static Error Deserialize(string serialized)
        {
            string[] data = serialized.Split(
                new[] { _separator },
                StringSplitOptions.RemoveEmptyEntries);

            Guard.Require(data.Length >= 2, $"Invalid error serialization: \"{serialized}\"");

            return new Error(data[0], data[1]);
        }
    }
}
