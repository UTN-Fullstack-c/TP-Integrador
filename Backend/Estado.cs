using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd
{
    public class Estado
    {
        public required string Nombre { get; set; }

        public Estado(string nombre)
        {
            Nombre = nombre;
        }

       
    }
}
