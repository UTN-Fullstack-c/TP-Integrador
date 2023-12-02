using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Localizaciones.Fabricas
{
    public class FabricaLago : FabricaDeZonas
    {
        public override Localizacion2D Crear(int x, int y)
        {
            return new Lago(x, y);
        }
    }
}
