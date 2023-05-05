using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Thera.Exceptions
{
    public class TheraException : Exception
    {
        public TheraException(string message) : base(message)
        {
        }
    }
}
