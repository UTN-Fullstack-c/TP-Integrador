using Backend.Robots;
using FrontEnd.CustomException;
using FrontEnd.MapaNamespace;
using FrontEnd.Menu.MenuCuartelNamespace.MenuRobotNamespace;
using FrontEnd.MenuNamespace;

namespace FrontEnd.Menu.MenuCuartelNamespace.EstadoRobots
{
    public class RobotsPorLocalizacion : ICommand
    {
        public void Ejecutar()
        {
            var consola = ConsolaCustom.Singleton();
            var mapa = MapaConsola.Singleton().Mapa;
            int x = consola.LeerEntero(
                0,
                mapa.LargoHorizontal(),
                "Latitud (x) de la ubicacion: ",
                ConsoleColor.White
                );
            int y = consola.LeerEntero(
                0,
                mapa.LargoVertical(),
                "Longitud (y) de la ubicacion: ",
                ConsoleColor.White
                ); 
            List<Robot> robots = ImprimirRobotsEn(x, y);
            if(consola.LeerBooleano("Desea realizar una operacion con alguno de los robots?"))
                SeleccionarRobots(robots);
        }

        private List<Robot> ImprimirRobotsEn(int x, int y)
        {
            var mapa = MapaConsola.Singleton().Mapa;
            List<Robot> robots = mapa.Get(x, y).RobotsEnZona;
            var consola = ConsolaCustom.Singleton();
            consola.Imprimir("\nLista de Robots en (" + x + "," + y + "): \n", ConsoleColor.Blue);
            if (robots.Count == 0)
                consola.Imprimir("No hay robots en (" + x + ", " + y + "): \n");
            else
                foreach (Robot robot in robots)
                    consola.Imprimir("\n" + robot.ToString() + "\n");
            return robots;
        }

        private void SeleccionarRobots(List<Robot> robots)
        {
            try
            {
                int opcionSeleccionada = SeleccionarOpcion(robots.Count) - 1;
                var consola = ConsolaCustom.Singleton();
                ICommand menu = null;
                if (consola.LeerBooleano("Desea que el robot que eligio interactue con otro?"))
                {
                    int segundaOpcionSeleccionada = SeleccionarOpcion(robots.Count);
                    menu = new MenuInteraccionRobots(
                        robots[opcionSeleccionada],
                        robots[segundaOpcionSeleccionada]
                    );
                    menu.Ejecutar();
                }
                else
                {
                    menu = new MenuRobot(robots[opcionSeleccionada]);
                }
                menu.Ejecutar();
            }
            catch (UserAbortException) { }
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
            return "Listar robots dada una localizacion.";
        }
    }
}
