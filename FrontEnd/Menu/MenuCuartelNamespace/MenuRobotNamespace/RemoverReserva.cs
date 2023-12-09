using Backend.Localizaciones;
using Backend.Robots;
using FrontEnd.MenuNamespace;
namespace FrontEnd.Menu.MenuCuartelNamespace.MenuRobotNamespace
{
    public class RemoverReserva : ICommand
    {
        private Robot Robot;

        public RemoverReserva(Robot robot)
        {
            Robot = robot;
        }

        public void Ejecutar()
        {
            if(! Robot.Cuartel.RemoverReserva(Robot))
                ConsolaCustom.Singleton().Imprimir("\nEl robot no se encontraba en la reserva\n", ConsoleColor.Red);
        }

        public override string ToString()
        {
            return "Quitar de la reserva (pasa a ser un robot activo).";
        }
    }
}
