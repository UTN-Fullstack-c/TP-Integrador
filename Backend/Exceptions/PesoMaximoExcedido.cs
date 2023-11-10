using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Exceptions
{
    public class PesoMaximoExcedido : Exception
    {
        public const string DESCRIPTION = "Peso maximo excedido. ";
        public PesoMaximoExcedido(string msg) 
            : base(DESCRIPTION +  msg) { }

        public PesoMaximoExcedido() 
            : base(DESCRIPTION) { }
    }
}
