using Backend.Localizaciones;
using FrontEnd.Menu;
using FrontEnd.Menu.MenuCuartelNamespace;
using FrontEnd.Menu.MenuCuartelNamespace.AgregarRobotNamespace;

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
            Commands.Add(new ListarRobots(Cuartel));
            Commands.Add(new MostrarMapa());
            Commands.Add(new MostrarUbicacion(Cuartel));
        }

        public void Ejecutar()
        {
        }
    }
}