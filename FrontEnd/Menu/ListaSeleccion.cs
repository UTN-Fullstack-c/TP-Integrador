using FrontEnd.CustomException;

namespace FrontEnd.MenuNamespace
{
    public class ListaSeleccion : ICommand
    {
        public List<ICommand> Commands { get; set; }
        private ConsolaCustom Consola { get; }
        protected string Titulo { get; }
        protected string Nombre { get; }

        public ListaSeleccion(string titulo)
        {
            Nombre = titulo;
            Consola = ConsolaCustom.Singleton();
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
                SeleccionUsuario();
            }
            catch (UserAbortException)
            {
                Consola.Imprimir(
                    "\nComo no quizo elegir una opcion se cerrara el menu.",
                    ConsoleColor.Green
                );
            }
            Console.ForegroundColor = color;
        }

        protected virtual void SeleccionUsuario()
        {
            ImprimirMenu();
            int numeroOpcion = SeleccionarOpcion() - 1;
            Commands[numeroOpcion].Ejecutar();
        }

        protected virtual void ImprimirMenu()
        {
            Consola.Imprimir(Titulo, ConsoleColor.Yellow);
            int i;
            for (i = 0; i < Commands.Count; i++)
                ImprimirOpcionMenu(i+1, Commands[i].ToString()!);
        }
        
        protected void ImprimirOpcionMenu(int numeroOpcion, string nombreOpcion)
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

        protected int SeleccionarOpcion()
        {
            var opcionSeleccionada = Consola.LeerEntero(
                1, 
                CantidadOpciones(),
                "\n\nIngrese el numero de opcion: ", 
                ConsoleColor.Yellow
            );
            return opcionSeleccionada;
        }

        protected virtual int CantidadOpciones()
        {
            return Commands.Count;
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
