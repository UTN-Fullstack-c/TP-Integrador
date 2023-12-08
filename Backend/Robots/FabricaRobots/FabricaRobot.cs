using Backend.Exceptions;
using Backend.Localizaciones;

namespace Backend.Robots.FabricaRobots
{
    public abstract class FabricaRobot
    {
        protected static int ultimoIdRobot = 0;

        public static Robot Crear(
            int tipo,
            float velocidadMax,
            Localizacion2D localizacion
            )
        {
            Robot robot = null;
            switch (tipo)
            {
                case 0:
                    robot = new FabricaUAV().Crear(velocidadMax, localizacion);
                    break;
                case 1:
                    robot = new FabricaK9().Crear(velocidadMax, localizacion);
                    break;
                case 2:
                    robot = new FabricaM8().Crear(velocidadMax, localizacion);
                    break;
                default:
                    throw new TipoProductoInvalido("No se pudo fabricar el robot.");
            }
            return robot;
        }

        public abstract Robot Crear(float velocidadMax, Localizacion2D localizacion);
    }
}
