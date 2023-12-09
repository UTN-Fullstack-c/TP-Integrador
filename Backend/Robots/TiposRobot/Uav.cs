using Backend.Estados;
using Backend.Localizaciones;
using Backend.Transferibles;

namespace Backend.Robots.TiposRobot
{
    public class Uav : Robot
    {
        public const int CONTENEDOR = 5;
        public const int BATERIA = 4000;

        public Uav(
            float velocidadMax,
            Localizacion2D localizacion,
            Cuartel cuartel
            )
            : base(
                  velocidadMax,
                  new Contenedor(CONTENEDOR),
                  new StandBy(),
                  new Bateria(BATERIA),
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
