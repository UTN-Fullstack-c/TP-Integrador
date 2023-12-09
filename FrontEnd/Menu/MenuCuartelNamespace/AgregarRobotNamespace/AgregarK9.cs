using Backend.Localizaciones;
using Backend.Robots.FabricaRobots;

namespace FrontEnd.Menu.MenuCuartelNamespace.AgregarRobotNamespace
{
    public class AgregarK9 : AgregarRobot
    {
        public AgregarK9(Cuartel cuartel)
            : base(new FabricaK9(), cuartel)

        {
        }

        public override string ToString()
        {
            return "Crear K9";
        }
    }
}
