using Backend.Localizaciones;
using Backend.Robots.FabricaRobots;

namespace FrontEnd.Menu.MenuCuartelNamespace.AgregarRobotNamespace
{
    public class AgregarM8 : AgregarRobot
    {
        public AgregarM8(Cuartel cuartel)
            : base(new FabricaK9(), cuartel)

        {
        }

        public override string ToString()
        {
            return "Crear M8";
        }
    }
}
