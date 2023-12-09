using Backend.Localizaciones;
using Backend.Robots.FabricaRobots;
using FrontEnd.MenuNamespace;

namespace FrontEnd.Menu.MenuCuartelNamespace.AgregarRobotNamespace
{
    public class MenuAgregarRobot : MenuConsola
    {
        protected FabricaRobot fabricaRobot;
        protected Cuartel Cuartel;

        public MenuAgregarRobot(Cuartel cuartel)
            : base ("Agregar robot al cuartel")
        {
            Cuartel = cuartel;
            Commands.Add(new AgregarK9(Cuartel));
            Commands.Add(new AgregarM8(Cuartel));
            Commands.Add(new AgregarUAV(Cuartel));
        }
    }
}
