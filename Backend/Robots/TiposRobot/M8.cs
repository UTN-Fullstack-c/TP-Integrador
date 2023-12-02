using Backend.Estados;
using Backend.Localizaciones;
using Backend.Transferibles;

namespace Backend.Robots.TiposRobot
{
    public class M8 : Robot
    {
        public M8(
            float velocidadMax,
            float pesoMax,
            Estado estado,
            Bateria? bateria,
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
