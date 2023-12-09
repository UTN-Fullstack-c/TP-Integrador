using Backend.Localizaciones;
using FrontEnd.MapaNamespace;
using FrontEnd.MenuNamespace;
using FrontEnd.MenuNamespace.MenuCuartelNamespace;
using FrontEnd.MenuNamespace.MenuMapaNamespace;

namespace FrontEnd.Menu
{
    public class MenuPrincipal : MenuConsola
    {
        public MenuPrincipal()
            : base("Menu principal")
        {
            var consola = ConsolaCustom.Singleton();
            Mapa mapa = MapaConsola.Singleton().Mapa!;
            if (mapa == null)
                consola.Imprimir("No hay un mapa cargado", ConsoleColor.Red);
            else
            {
                foreach (var cuartel in mapa.Cuarteles)
                    Commands.Add(new MenuCuartel(cuartel));
                Commands.Add(new MostrarMapa());
                Commands.Add(new ListarRobotsPorLocalizacion());
            }
        }
    }
}
