using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Exceptions
{
    public class SobrecargaBateria : Exception
    {
        public const string DESCRIPTION =
            "Se esta intentando cargar mas mA de los que soporta la bateria. ";

        public SobrecargaBateria()
            : base(DESCRIPTION) { }
    }
}
