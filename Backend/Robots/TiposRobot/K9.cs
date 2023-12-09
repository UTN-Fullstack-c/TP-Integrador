using Backend.Estados;
using Backend.Localizaciones;
using Backend.Transferibles;

namespace Backend.Robots.TiposRobot
{
    public class K9 : Robot
    {
        public K9(
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
        public override string ToString()
        {
            return "Modelo: K9\n" + base.ToString();
        }
    }
}
