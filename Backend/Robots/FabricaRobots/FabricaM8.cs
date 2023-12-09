using Backend.Estados;
using Backend.Localizaciones;
using Backend.Robots.TiposRobot;
using Backend.Transferibles;

namespace Backend.Robots.FabricaRobots
{
    public class FabricaM8 : FabricaRobot
    {
        public override Robot Crear(float velocidadMax, Localizacion2D localizacion, Cuartel cuartel)
        {
            return new M8(
                velocidadMax,
                new Contenedor(250),
                new StandBy(),
                new Bateria(12250),
                ultimoIdRobot++,
                localizacion,
                cuartel
            );
        }
    }
}
