using Backend.Estados;
using Backend.Localizaciones;
using Backend.Transferibles;

namespace Backend.Robots.TiposRobot
{
    public class M8 : Robot
    {
        public const int CONTENEDOR = 250;
        public const int BATERIA = 12250;
        public M8(
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
            return "Modelo: M8\n" + base.ToString();
        }
    }
}
