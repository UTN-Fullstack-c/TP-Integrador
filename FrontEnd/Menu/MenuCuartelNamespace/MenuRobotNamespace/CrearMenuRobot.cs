using Backend.Localizaciones;
using Backend.Robots;
using FrontEnd.CustomException;
using FrontEnd.MenuNamespace;
using System;

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
            int cantidadOpciones = ImprimirListaRobots();
            AbrirMenuRobot(cantidadOpciones);
        }

        private int ImprimirListaRobots()
        {
            var consola = ConsolaCustom.Singleton();
            consola.Imprimir("\nSeleccione un robot\n", ConsoleColor.Yellow);
            int i = 0;
            for (i = 0; i < Cuartel.RobotsActivos.Count; i++)
            {
                Robot robot = Cuartel.RobotsActivos[i];
                consola.Imprimir("\n" + (i + 1) + ") ", ConsoleColor.Yellow);
                consola.Imprimir(robot.GetNombre() + ".");
            }
            for (int r = 0; r < Cuartel.Reserva.Count; r++)
            {
                Robot robot = Cuartel.Reserva[r];
                consola.Imprimir("\n" + (i + 1) + ") ", ConsoleColor.Yellow);
                consola.Imprimir(robot.GetNombre() + " (Reserva).");
            }
            var cantidadOpciones = i + 1;
            return cantidadOpciones;
        }

        private void AbrirMenuRobot(int cantidadOpciones)
        {
            try
            {
                int opcionSeleccionada = SeleccionarOpcion(cantidadOpciones);
                Robot robot = null;
                if (opcionSeleccionada > Cuartel.RobotsActivos.Count)
                {
                    opcionSeleccionada -= Cuartel.RobotsActivos.Count;
                    robot = Cuartel.Reserva[opcionSeleccionada - 1];
                }
                else
                    robot = Cuartel.RobotsActivos[opcionSeleccionada - 1];
                var menuRobot = new MenuRobot(robot);
                menuRobot.Ejecutar();
            }
            catch (UserAbortException e)
            { }
        }

        private int SeleccionarOpcion(int max)
        {
            var consola = ConsolaCustom.Singleton();
            return consola.LeerEntero(
                    0,
                    max,
                    "\n\nSeleccione una opcion: ",
                    ConsoleColor.Yellow
                );
        }

        public override string ToString()
        {
            return "Seleccionar Robot";
        }
    }
}
