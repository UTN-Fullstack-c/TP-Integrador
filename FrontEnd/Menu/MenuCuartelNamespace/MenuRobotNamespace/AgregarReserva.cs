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
            if (!Cuartel.AgregarReserva(robot))
                ConsolaCustom.Singleton().Imprimir("\nEl robot ya estaba en la reserva\n", ConsoleColor.Red);
        }

        public override string ToString()
        {
            return "Agregar a la reserva.";
        }
    }
}
