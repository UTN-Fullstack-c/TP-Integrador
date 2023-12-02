using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Localizaciones.Fabricas
{
    public class FabricaCuartel : FabricaDeZonas<Cuartel>
    {
        public override Cuartel Crear(int x, int y)
        {
            return new Cuartel(x, y);
        }
    }
}
