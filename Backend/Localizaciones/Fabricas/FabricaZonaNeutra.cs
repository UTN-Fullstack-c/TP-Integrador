using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Localizaciones.Fabricas
{
    public class FabricaZonaNeutra : FabricaDeZonas
    {
        public override Localizacion2D Crear(int x, int y)
        {
            Random random = new Random();
            int t = random.Next(4);
            string[] terrenos = { "Baldío", "Planicie", "Bosque", "Urbano" };
            return new Localizacion2D(x, y, terrenos[t]);
        }
    }
}
