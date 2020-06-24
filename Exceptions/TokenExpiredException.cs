using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShikiHuiki.Exceptions
{
    class TokenExpiredException : Exception
    {
        internal TokenExpiredException() : base("Main auth method failed, try refresh method")
        {

        }
    }
}
