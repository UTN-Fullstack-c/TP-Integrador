using Backend.Localizaciones;
using Backend.Robots;
using FrontEnd.Menu.MenuMapaNamespace;
using FrontEnd.MenuNamespace;

namespace FrontEnd.Menu.MenuCuartelNamespace.MenuRobotNamespace
{
    public class MenuRobot : MenuConsola
    {
        public MenuRobot(Robot robot) 
            : base("Gestionar robot " + robot.GetNombre())
        {
            Commands.Add(new AgregarReserva(robot));
            Commands.Add(new RemoverReserva(robot));
            Commands.Add(new RegresarCuartel(robot));
            Commands.Add(new EnviarHacia(robot));
            Commands.Add(new MostrarMapa());
            Commands.Add(new MostrarUbicacion(robot));
            Commands.Add(new MostrarEstado(robot));
        }
    }
}
