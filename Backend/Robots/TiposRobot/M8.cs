using Backend.Estados;
using Backend.Localizaciones;
using Backend.Transferibles;

namespace Backend.Robots.TiposRobot
{
    public class M8 : Robot
    {
        public M8(
            float velocidadMax,
            Contenedor contenedor,
            Estado estado,
            Bateria? bateria,
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
            return "Modelo: M8\n" + base.ToString();
        }
    }
}
