using Backend.Estados;
using Backend.Localizaciones;
using Backend.Transferibles;

namespace Backend.Robots.TiposRobot
{
    public class Uav : Robot
    {
        public Uav(
            float velocidadMax,
            float pesoMax,
            Estado estado,
            Bateria bateria,
            int id,
            Localizacion2D localizacion
            )
            : base(
                  velocidadMax,
                  pesoMax,
                  estado,
                  bateria,
                  id,
                  localizacion
            )
        {
        }
    }
}
