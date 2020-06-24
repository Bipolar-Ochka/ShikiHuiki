using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShikiHuiki.Exceptions
{
    class FailedRequestException : Exception
    {
        internal FailedRequestException() : base("Request didnt returned OK code")
        {

        }
    }
}
