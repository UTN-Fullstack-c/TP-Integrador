using FrontEnd.CustomException;
using FrontEnd.Menu;

namespace FrontEnd.MenuNamespace
{
    public class MenuConsola : ListaSeleccion
    {
        public MenuConsola(string titulo) : base(titulo)
        {
            Commands.Add(new LimpiarPantalla(this));
        }

        protected override void SeleccionUsuario()
        {
            bool continuar = true;
            while(continuar) 
            {
                ImprimirMenu();
                int numeroOpcion = SeleccionarOpcion() - 1;
                if(numeroOpcion == Commands.Count)
                    continuar = false;
                else
                    Commands[numeroOpcion].Ejecutar();
            }
        }

        protected override void ImprimirMenu()
        {
            base.ImprimirMenu();
            ImprimirOpcionMenu(Commands.Count+1, "Salir");
        }
        protected override int CantidadOpciones()
        {
            return base.CantidadOpciones() + 1;
        }
    }
}
