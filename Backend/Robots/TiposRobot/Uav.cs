using Backend.Estados;
using Backend.Localizaciones;
using Backend.Transferibles;

namespace Backend.Robots.TiposRobot
{
    public class Uav : Robot
    {
        public Uav(
            float velocidadMax,
            Contenedor contenedor,
            Estado estado,
            Bateria bateria,
            int id,
            Localizacion2D localizacion,
            Cuartel cuartel
            )
            : base(
                  velocidadMax,
                  contenedor,
                  estado,
                  bateria,
                  id,
                  localizacion,
                  cuartel
            )
        {
        }

        public override string ToString()
        {
            return "Modelo: UAV\n" + base.ToString();
        }
    }
}
