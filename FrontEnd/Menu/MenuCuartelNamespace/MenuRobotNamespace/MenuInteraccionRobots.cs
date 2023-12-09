using Backend.Robots;
using FrontEnd.MenuNamespace;

namespace FrontEnd.Menu.MenuCuartelNamespace.MenuRobotNamespace
{
    public class MenuInteraccionRobots : MenuConsola
    {
        public MenuInteraccionRobots(Robot robotDestino, Robot robotOrigen)
            : base ("Interaccion desde " + robotOrigen.GetNombre() + " hacia " + robotDestino.GetNombre())
        {
            Commands.Add(new TransferirBateria(robotOrigen, robotDestino));
            Commands.Add(new TransferirCargaFisica(robotOrigen, robotDestino));
        }

        public void Ejecutar()
        {
            throw new NotImplementedException();
        }
    }
}
