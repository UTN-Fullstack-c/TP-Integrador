using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Localizaciones.Fabricas.Edificio
{
    public class FabricaCuartel : FabricaDeEdificios<Cuartel>
    {
        public override Cuartel Crear(int x, int y, int numeroCuartel)
        {
            return new Cuartel(x, y, numeroCuartel);
        }
    }
}
