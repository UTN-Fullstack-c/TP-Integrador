using Backend.Robots;

namespace Backend.Localizaciones
{
    public class Reciclaje : Localizacion2D, PuntoDeCarga
    {
        public Reciclaje(int x, int y, int numeroDeReciclaje) 
            : base(x, y, "Sitio de Reciclaje " + numeroDeReciclaje)
        {
        }

        public override bool Hospedar(Robot robot)
        {
            return base.Hospedar(robot);
        }

        public void Reparar(Robot robot)
        {
            robot.Bateria.CompletarCarga();
        }
    }
}
