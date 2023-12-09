using Backend.Localizaciones;
using Backend.Robots;
using FrontEnd.Menu.MenuMapaNamespace;
using FrontEnd.MenuNamespace;

namespace FrontEnd.Menu.MenuCuartelNamespace.MenuRobotNamespace
{
    public class MenuRobot : MenuConsola
    {
        public MenuRobot(Cuartel cuartel, Robot robot) 
            : base("Gestionar robot " + robot.GetNombre())
        {
            Commands.Add(new AgregarReserva(cuartel, robot));
            Commands.Add(new RemoverReserva(cuartel, robot));
            Commands.Add(new RegresarCuartel(cuartel, robot));
            Commands.Add(new EnviarHacia(cuartel, robot));
            Commands.Add(new MostrarMapa());
            Commands.Add(new MostrarUbicacion(robot));
        }
    }
}
