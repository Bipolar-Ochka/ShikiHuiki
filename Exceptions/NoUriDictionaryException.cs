using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShikiHuiki.Exceptions
{
    class NoUriDictionaryException :Exception
    {
        internal NoUriDictionaryException() : base("No such uri in URI.ShikiUris dictionary") 
        { 

        }
    }
}
