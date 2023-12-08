using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Localizaciones.Fabricas.Zona
{
    public abstract class FabricaDeZonas
    {
        public static Localizacion2D Crear(int tipo, int x, int y)
        {
            switch (tipo)
            {
                case 0:
                    return new FabricaVertederos().Crear(x, y);
                case 1:
                    return new FabricaVertederoElectronico().Crear(x, y);
                case 2:
                    return new FabricaLago().Crear(x, y);
                default:
                    return new FabricaZonaNeutra().Crear(x, y);
            }
            throw new Exception("tipo invalido");
        }

        public abstract Localizacion2D Crear(int x, int y);
    }
}
