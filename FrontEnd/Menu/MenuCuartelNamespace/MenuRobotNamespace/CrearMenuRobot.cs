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
            if (Cuartel.RobotsActivos.Count == 0 && Cuartel.Reserva.Count == 0)
            {
                consola.Imprimir("\nEl cuartel no tiene robots\n", ConsoleColor.Red);
                return;
            }
            consola.Imprimir("\nSeleccione un robot\n", ConsoleColor.Yellow);
            int i = 0;
            for (i = 0; i < Cuartel.RobotsActivos.Count; i++)
            {
                Robot robot = Cuartel.RobotsActivos[i];
                consola.Imprimir("\n" + (i + 1) + ") ", ConsoleColor.Yellow);
                consola.Imprimir(robot.GetNombre() + ".");
            }
            for (int j=0; j < Cuartel.Reserva.Count; j++)
            {
                Robot robot = Cuartel.Reserva[j];
                consola.Imprimir("\n" + (i + 1) + ") ", ConsoleColor.Yellow);
                consola.Imprimir(robot.GetNombre() + " (Reserva).");
            }
            try
            {
                int opcionSeleccionada = consola.LeerEntero(
                    0,
                    i+1,
                    "\n\nSeleccione una opcion: ",
                    ConsoleColor.Yellow
                );
                Robot robot= null;
                if (opcionSeleccionada > Cuartel.RobotsActivos.Count)
                {
                    opcionSeleccionada -= Cuartel.RobotsActivos.Count;
                    robot = Cuartel.Reserva[opcionSeleccionada - 1];
                }
                else
                    robot = Cuartel.RobotsActivos[opcionSeleccionada - 1];
                var menuRobot = new MenuRobot(Cuartel, robot);
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
