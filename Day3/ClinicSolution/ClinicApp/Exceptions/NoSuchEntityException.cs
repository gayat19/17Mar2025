using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.Exceptions
{
    public  class NoSuchEntityException : Exception
    {
        public NoSuchEntityException() : base("No such entity found")
        {

        }
        public NoSuchEntityException(string message) : base(message)
        {

        }
    }
}
