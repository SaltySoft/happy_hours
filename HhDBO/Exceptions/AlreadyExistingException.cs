using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HhDBO.Exceptions
{
    public class AlreadyExistingException : Exception
    {
        public AlreadyExistingException()
        {
        }

        public AlreadyExistingException(string message)
            : base(message)
        {
        }
    }
}
