using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryCult.Services.Exceptions
{
    public class DbConcurencyException : ApplicationException
    {
        public DbConcurencyException (string message) : base(message)
        {
        }
    }
}
