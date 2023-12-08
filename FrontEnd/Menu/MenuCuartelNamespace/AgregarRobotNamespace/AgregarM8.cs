using Backend.Localizaciones;
using Backend.Robots.FabricaRobots;

namespace FrontEnd.Menu.MenuCuartelNamespace.AgregarRobotNamespace
{
    public class AgregarM8 : AgregarRobot
    {
        public AgregarM8(Cuartel cuartel)
            : base(cuartel)

        {
            fabricaRobot = new FabricaK9();
        }

        public override string ToString()
        {
            return "Crear K9";
        }
    }
}
