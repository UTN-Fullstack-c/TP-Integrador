using Backend.Estados;
using Backend.Localizaciones;
using Backend.Robots.TiposRobot;
using Backend.Transferibles;

namespace Backend.Robots
{
    public class FabricaRobot
    {
        public Uav CreateUAV(
            float velocidadMax, 
            int id, 
            Localizacion2D localizacion
            )
        {
            return new Uav(
                velocidadMax,
                5,
                new StandBy(),
                new Bateria(4000),
                id,
                localizacion
            );
        }

        public K9 CreateK9(
            float velocidadMax,
            int id,
            Localizacion2D localizacion
            )
        {
            return new K9(
                velocidadMax,
                40,
                new StandBy(),
                new Bateria(6500),
                id,
                localizacion
            );
        }

        public M8 CreateM8(
            float velocidadMax,
            int id,
            Localizacion2D localizacion
            )
        {
            return new M8(
                velocidadMax,
                250,
                new StandBy(),
                new Bateria(12250),
                id,
                localizacion
            );
        }
        
    }
}
