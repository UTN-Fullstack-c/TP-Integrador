using Backend.Localizaciones;
using Backend.Robots;
using FrontEnd.MenuNamespace;

namespace FrontEnd.Menu.MenuCuartelNamespace.EstadoRobots
{
    public class ListarEstadoRobots : ICommand
    {
        private Cuartel Cuartel;

        public ListarEstadoRobots(Cuartel cuartel)
        {
            Cuartel = cuartel;
        }

        public void Ejecutar()
        {
            var consola = ConsolaCustom.Singleton();
            ImprimirLista("activos", Cuartel.RobotsActivos);
            ImprimirLista("en reserva", Cuartel.Reserva);
        }

        private void ImprimirLista(string nombreLista, List<Robot> robots)
        {
            var consola = ConsolaCustom.Singleton();
            string titulo = "\nRobots " + nombreLista + ":\n";
            int size = titulo.Length;
            for (int i = 0; i < size; i++)
                titulo += "-";
            consola.Imprimir(titulo + "\n", ConsoleColor.Blue);
            if (robots.Count == 0)
                consola.Imprimir("No hay robots " + nombreLista + "\n");
            else
                foreach (var robot in robots)
                    consola.Imprimir("\n" + robot.ToString() + "\n");
        }

        public override string ToString()
        {
            return "Listar estado de todos los robots del cuartel";
        }
    }
}
