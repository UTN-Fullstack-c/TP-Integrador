using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Exceptions
{
    public class BateriaInsuficiente : Exception
    {
        public const string DESCRIPTION = 
            "No hay suficiente bateria para realizar la operacion. ";
        public BateriaInsuficiente(string message)
            : base(DESCRIPTION + message) { }

        public BateriaInsuficiente()
            : base(DESCRIPTION) { }
    }
}
