using Backend.Localizaciones;
using Backend.Robots;
using FrontEnd.CustomException;
using FrontEnd.MenuNamespace;

namespace FrontEnd.Menu.MenuCuartelNamespace.MenuRobotNamespace
{
    public class CrearMenuRobot : ICommand
    {
        private Cuartel Cuartel;
        public CrearMenuRobot(Cuartel cuartel)
        {
            Cuartel = cuartel;
        }

        public void Ejecutar()
        {
            var consola = ConsolaCustom.Singleton();
            consola.Imprimir("\nSeleccione un robot\n", ConsoleColor.Yellow);
            for (int i = 0; i < Cuartel.RobotsActivos.Count; i++)
            {
                Robot robot = Cuartel.RobotsActivos[i];
                consola.Imprimir("\n" + (i + 1) + ") ", ConsoleColor.Yellow);
                consola.Imprimir(robot.GetNombre() + ".");
            }
            try
            {
                int opcionSeleccionada = consola.LeerEntero(
                    0,
                    Cuartel.RobotsActivos.Count,
                    "\n\nSeleccione una opcion: ",
                    ConsoleColor.Yellow
                );
                var menuRobot = new MenuRobot(Cuartel, Cuartel.RobotsActivos[opcionSeleccionada - 1]);
                menuRobot.Ejecutar();
            }
            catch(UserAbortException e) 
            { }
        }

        public override string ToString()
        {
            return "Seleccionar Robot";
        }
    }
}
