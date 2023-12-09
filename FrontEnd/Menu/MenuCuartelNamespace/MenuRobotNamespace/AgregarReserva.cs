using Backend.Localizaciones;
using Backend.Robots;
using FrontEnd.MenuNamespace;
namespace FrontEnd.Menu.MenuCuartelNamespace.MenuRobotNamespace
{
    public class AgregarReserva : ICommand
    {
        private Robot Robot;

        public AgregarReserva(Robot robot)
        {
            Robot = robot;
        }

        public void Ejecutar()
        {
            if (!Robot.Cuartel.AgregarReserva(Robot))
                ConsolaCustom.Singleton().Imprimir("\nEl robot ya estaba en la reserva\n", ConsoleColor.Red);
        }

        public override string ToString()
        {
            return "Agregar a la reserva.";
        }
    }
}
