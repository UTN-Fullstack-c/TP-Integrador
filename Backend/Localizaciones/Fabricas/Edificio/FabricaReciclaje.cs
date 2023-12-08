using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Localizaciones.Fabricas.Edificio
{
    public class FabricaReciclaje : FabricaDeEdificios<Reciclaje>
    {
        public override Reciclaje Crear(int x, int y, int numeroDeEdificio)
        {
            return new Reciclaje(x, y, numeroDeEdificio);
        }
    }
}
