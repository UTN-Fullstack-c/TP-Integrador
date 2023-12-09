using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Transferibles
{
    public class Bateria : Transferible
    {
        public int MiliAmperiosDeFabrica;

        public Bateria(int miliAmperiosMax) : base(miliAmperiosMax, "mA")
        {
            MiliAmperiosDeFabrica = miliAmperiosMax;
        }

        public override string ToString()
        {
            return base.ToString() + ". De fabrica viene con " + MiliAmperiosDeFabrica + "mA";
        }

        public void Reparar()
        {
            _max = MiliAmperiosDeFabrica;
        }
    }
}
