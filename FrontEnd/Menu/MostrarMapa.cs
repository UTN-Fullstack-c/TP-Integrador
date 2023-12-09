using FrontEnd.MapaNamespace;
using FrontEnd.MenuNamespace;

namespace FrontEnd.Menu
{
    public class MostrarMapa : ICommand
    {
        public void Ejecutar()
        {
            var consola = ConsolaCustom.Singleton();
            MapaConsola mapaUI = MapaConsola.Singleton();
            if (mapaUI.Mapa == null)
                consola.Imprimir("No hay ningun mapa cargado");
            mapaUI.Imprimir();
        }

        public override string ToString()
        {
            return "Mostrar mapa";
        }
    }
}
