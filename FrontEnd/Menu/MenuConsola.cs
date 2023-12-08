using FrontEnd.CustomException;

namespace FrontEnd.MenuNamespace
{
    public class MenuConsola : ICommand
    {
        public List<ICommand> Commands { get; }
        private ConsolaCustom Consola { get; }
        private string Titulo { get; }

        public MenuConsola(string titulo)
        {
            Consola = ConsolaCustom.CrearConsola();
            this.Commands = new List<ICommand>();
            Titulo = "\n" + titulo + ":\n";
            for (int i = 0; i <= titulo.Length; i++)
                Titulo += '-';
            Titulo += "\n";
        }

        public virtual void Ejecutar()
        {
            ConsoleColor color = Console.ForegroundColor;
            try
            {
                EjecutarMenu();
            }
            catch (UserAbortException)
            {
                Consola.Imprimir(
                    "\nComo no quizo elegir una opcion se cerrara el menu.",
                    ConsoleColor.Green
                );
            }
            Consola.Imprimir("\nPresione una tecla para continuar");
            Console.ReadKey();
            Console.ForegroundColor = color;
        }

        private void EjecutarMenu()
        {
            bool continuar = true;
            while (continuar)
            {
                ImprimirMenu();
                int i = SeleccionarOpcion() - 1;
                if (i == Commands.Count)
                    continuar = false;
                else
                    Commands[i].Ejecutar();
            }
        }

        private void ImprimirMenu()
        {
            Consola.Imprimir(Titulo, ConsoleColor.Yellow);
            int i;
            for (i = 0; i < Commands.Count; i++)
                ImprimirOpcionMenu(i+1, Commands[i].ToString()!);
            ImprimirOpcionMenu(i + 1, "Salir");
            Consola.Imprimir("\n");
        }
        
        private void ImprimirOpcionMenu(int numeroOpcion, string nombreOpcion)
        {
            Consola.Imprimir(
                "\n" + (numeroOpcion) + ") ", 
                ConsoleColor.Yellow
            );
            Consola.Imprimir(
                nombreOpcion, 
                ConsoleColor.White
            );
        }

        private int SeleccionarOpcion()
        {
            var opcionSeleccionada = Consola.LeerEntero(
                1, 
                Commands.Count+1,
                "\nIngrese el numero de opcion: ", 
                ConsoleColor.Yellow
            );
            return opcionSeleccionada;
        }

        public override string ToString()
        {
            return Titulo;
        }
    }
}
