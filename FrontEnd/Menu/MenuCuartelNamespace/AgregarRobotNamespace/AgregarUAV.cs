using Backend.Localizaciones;
using Backend.Robots.FabricaRobots;

namespace FrontEnd.Menu.MenuCuartelNamespace.AgregarRobotNamespace
{
    public class AgregarUAV : AgregarRobot
    {
        public AgregarUAV(Cuartel cuartel)
            : base(cuartel)

        {
            fabricaRobot = new FabricaUAV();
        }

        public override string ToString()
        {
            return "Crear UAV";
        }
    }
}
