using Backend.Estados;
using Backend.Localizaciones;
using Backend.Robots.TiposRobot;
using Backend.Transferibles;

namespace Backend.Robots.FabricaRobots
{
    public class FabricaM8 : FabricaRobot
    {
        public override Robot Crear(float velocidadMax, Localizacion2D localizacion)
        {
            return new M8(
                velocidadMax,
                250,
                new StandBy(),
                new Bateria(12250),
                ultimoIdRobot++,
                localizacion
            );
        }
    }
}
