using Backend.Estados;
using Backend.Localizaciones;
using Backend.Transferibles;

namespace Backend.Robots.TiposRobot
{
    public class K9 : Robot
    {
        public const int CONTENEDOR = 40;
        public const int BATERIA = 6500;
        public K9(
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
            return "Modelo: K9\n" + base.ToString();
        }
    }
}
