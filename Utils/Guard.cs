using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendingMessagesService
{
    public static class Guard
    {
        public static void Require(bool _Result, string _ErrorMessage)
        {
            if (_ErrorMessage == null)
                _ErrorMessage = "ErrorMessage is null!";

            if (!_Result)
                throw new InvalidOperationException(_ErrorMessage);
        }
    }
}
