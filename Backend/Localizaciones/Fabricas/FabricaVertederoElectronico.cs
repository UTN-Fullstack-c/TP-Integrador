using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Localizaciones.Fabricas
{
    public class FabricaVertederoElectronico : FabricaDeZonas
    {
        public override Localizacion2D Crear(int x, int y)
        {
            return new VertederoElectronico(x, y);
        }
    }
}
