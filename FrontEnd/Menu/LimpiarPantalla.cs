using FrontEnd.MenuNamespace;

namespace FrontEnd.Menu
{
    public class LimpiarPantalla : ICommand
    {
        private MenuConsola MenuConsola;
        public LimpiarPantalla(MenuConsola menuConsola) 
        {
            MenuConsola = menuConsola;
        }

        public void Ejecutar()
        {
            Console.Clear();
            MenuConsola.Ejecutar();
        }

        public override string ToString()
        {
            return "Limpiar pantalla";
        }
    }
}
