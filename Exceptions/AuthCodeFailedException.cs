using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShikiHuiki.Exceptions
{
    class AuthCodeFailedException : Exception
    {
        public AuthCodeFailedException() : base("Wrong auth code or network trouble")
        {

        }
    }
}
