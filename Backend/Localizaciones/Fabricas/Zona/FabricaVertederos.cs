using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Localizaciones.Fabricas.Zona
{
    public class FabricaVertederos : FabricaDeZonas
    {
        public override Localizacion2D Crear(int x, int y)
        {
            return new Vertedero(x, y);
        }
    }
}
