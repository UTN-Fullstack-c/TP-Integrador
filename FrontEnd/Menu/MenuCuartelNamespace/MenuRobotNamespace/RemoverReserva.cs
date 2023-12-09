using Backend.Localizaciones;
using Backend.Robots;
using FrontEnd.MenuNamespace;
namespace FrontEnd.Menu.MenuCuartelNamespace.MenuRobotNamespace
{
    public class RemoverReserva : ICommand
    {
        private Cuartel Cuartel;
        private Robot robot;

        public RemoverReserva(Cuartel cuartel, Robot robot)
        {
            Cuartel = cuartel;
            this.robot = robot;
        }

        public void Ejecutar()
        {
            if(! Cuartel.RemoverReserva(robot))
                ConsolaCustom.Singleton().Imprimir("\nEl robot no se encontraba en la reserva\n", ConsoleColor.Red);
        }

        public override string ToString()
        {
            return "Quitar de la reserva (pasa a ser un robot activo).";
        }
    }
}
