using Backend.Estados;
using Backend.Localizaciones;
using Backend.Robots.TiposRobot;
using Backend.Transferibles;

namespace Backend.Robots.FabricaRobots
{
    public class FabricaUAV : FabricaRobot
    {
        public override Robot Crear(float velocidadMax, Localizacion2D localizacion)
        {
            return new Uav(
                velocidadMax,
                5,
                new StandBy(),
                new Bateria(4000),
                ultimoIdRobot++,
                localizacion
            );
        }
    }
}
