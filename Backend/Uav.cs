using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd
{
    class Uav : Robot
    {
        public int Altitud { get; set; }

        public Uav(int bateria, int velocidad, int altitud) : base(bateria, velocidad)
        {
           Altitud = altitud;
        }
    }
}
