using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.CustomException
{
    public class UserAbortException : Exception
    {
        private const string DESCRIPTION = "No existe el tipo para el objeto que se intenta fabricar. ";

        public UserAbortException(string mensaje) 
            : base( DESCRIPTION + mensaje)
        { }
    }
}
