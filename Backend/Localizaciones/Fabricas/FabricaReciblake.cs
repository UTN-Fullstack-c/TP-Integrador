using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Localizaciones.Fabricas
{
    public class FabricaReciblake : FabricaDeZonas<Reciclaje>
    {
        public override Reciclaje Crear(int x, int y)
        {
            return new Reciclaje(x, y);
        }
    }
}
