using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendingMessagesService.Errors
{
    public static class ErrorExtensions
    {
        public static string Serialize(this string _ErrorMessage)
        {
            Error error = Errors.General.ValueIsInvalid(_ErrorMessage);
            return error.Serialize();
        }
    }
}
