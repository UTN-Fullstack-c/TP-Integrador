using Backend.Localizaciones;
using Backend.Robots;
using Backend.Robots.FabricaRobots;
using FrontEnd.MapaNamespace;
using FrontEnd.MenuNamespace;
using System.Drawing;

namespace FrontEnd.Menu.MenuCuartelNamespace.AgregarRobotNamespace
{
    public abstract class AgregarRobot : MenuConsola
    {
        protected FabricaRobot fabricaRobot;
        protected Cuartel Cuartel;

        protected AgregarRobot(Cuartel cuartel)
            : base ("Agregar robot")
        {
            Cuartel = cuartel;
        }

        public AgregarRobot() : base("Agregar robot al cuartel")
        {
        }

        public override void Ejecutar()
        {
            var consola = ConsolaCustom.CrearConsola();
            var color = ConsoleColor.Yellow;
            var msgVelMax = "Ingrese la velocidad maxima : ";
            float velocidadMaxima = consola.LeerEntero(1, null, msgVelMax, color);
            Robot robot = fabricaRobot.Crear(velocidadMaxima, Cuartel);
            Cuartel.AgregarRobot(robot);
        }
    }
}
