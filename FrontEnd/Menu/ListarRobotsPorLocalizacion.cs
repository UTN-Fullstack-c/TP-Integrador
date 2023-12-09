using Backend.Robots;
using FrontEnd.MapaNamespace;
using FrontEnd.MenuNamespace;

namespace FrontEnd.Menu
{
    public class ListarRobotsPorLocalizacion : ICommand
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
            List<Robot> robos = mapa.Get(x, y).RobotsEnZona;
            consola.Imprimir("\nLista de Robots en (" + x + "," + y + "): \n", ConsoleColor.Blue);
            if (robos.Count == 0)
                consola.Imprimir("No hay robots en (" + x + ", " + y + "): \n");
            else
                foreach (Robot robot in robos)
                    consola.Imprimir("\n"+ robot.ToString() + "\n");
        }

        public override string ToString()
        {
            return "Listar robots dada una localizacion.";
        }
    }
}
