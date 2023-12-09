using Backend.Localizaciones;
using Backend.Robots;
using FrontEnd.MenuNamespace;
namespace FrontEnd.Menu.MenuCuartelNamespace.MenuRobotNamespace
{
    public class AgregarReserva : ICommand
    {
        private Cuartel Cuartel;
        private Robot robot;

        public AgregarReserva(Cuartel cuartel, Robot robot)
        {
            Cuartel = cuartel;
            this.robot = robot;
        }

        public void Ejecutar()
        {
            Cuartel.AgregarReserva(robot);
        }

        public override string ToString()
        {
            return "Agregar a la reserva.";
        }
    }
}
