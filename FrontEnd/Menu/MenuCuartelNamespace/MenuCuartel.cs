using Backend.Localizaciones;
using FrontEnd.Menu;
using FrontEnd.Menu.MenuCuartelNamespace;
using FrontEnd.Menu.MenuCuartelNamespace.AgregarRobotNamespace;
using FrontEnd.Menu.MenuCuartelNamespace.MenuRobotNamespace;
using FrontEnd.Menu.MenuMapaNamespace;
using FrontEnd.MenuNamespace.MenuMapaNamespace;

namespace FrontEnd.MenuNamespace.MenuCuartelNamespace
{
    public class MenuCuartel : MenuConsola
    {
        private Cuartel Cuartel { get; }

        public MenuCuartel(Cuartel cuartel)
            : base("Gestionar " + cuartel.NombreTerreno)
        {
            Cuartel = cuartel;
            Commands.Add(new MenuAgregarRobot(Cuartel));
            Commands.Add(new ListarEstadoRobots(Cuartel));
            Commands.Add(new MostrarMapa());
            Commands.Add(new MostrarUbicacion(Cuartel));
            Commands.Add(new CrearMenuRobot(Cuartel));
        }

        public void Ejecutar()
        {
        }
    }
}