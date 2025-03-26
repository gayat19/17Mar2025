using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.Exceptions
{
    public class CollectionEmptyException : Exception
    {
        public CollectionEmptyException():base("Collection is empty")
        {
            
        }
        public CollectionEmptyException(string message) : base(message)
        {

        }
        
    }
}
