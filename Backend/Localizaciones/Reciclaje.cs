using Backend.Robots;

namespace Backend.Localizaciones
{
    public class Reciclaje : Localizacion2D, PuntoDeCarga
    {
        public Reciclaje(int x, int y) : base(x, y, "Sitio de Reciclaje")
        {
        }

        public override bool Hospedar(Robot robot)
        {
            return base.Hospedar(robot);
        }

        public void RecargarBateria(Robot robot)
        {
            robot.Bateria.RecargarBateriaCompleta();
        }
    }
}
