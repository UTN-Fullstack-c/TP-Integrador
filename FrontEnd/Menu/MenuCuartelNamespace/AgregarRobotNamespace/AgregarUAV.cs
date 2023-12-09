using Backend.Localizaciones;
using Backend.Robots.FabricaRobots;

namespace FrontEnd.Menu.MenuCuartelNamespace.AgregarRobotNamespace
{
    public class AgregarUAV : AgregarRobot
    {
        public AgregarUAV(Cuartel cuartel)
            : base(new FabricaUAV(), cuartel)

        {
        }

        public override string ToString()
        {
            return "Crear UAV";
        }
    }
}
