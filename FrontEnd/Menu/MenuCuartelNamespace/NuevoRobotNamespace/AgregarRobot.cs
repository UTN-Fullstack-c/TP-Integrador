using Backend.Localizaciones;
using Backend.Robots;
using Backend.Robots.FabricaRobots;
using FrontEnd.MenuNamespace;

namespace FrontEnd.Menu.MenuCuartelNamespace.AgregarRobotNamespace
{
    public abstract class AgregarRobot : ICommand
    {
        private FabricaRobot fabricaRobot;
        private Cuartel Cuartel;

        protected AgregarRobot(FabricaRobot fabricaRobot, Cuartel cuartel)
        {
            this.fabricaRobot = fabricaRobot;
            Cuartel = cuartel;
        }

        public void Ejecutar()
        {
            var consola = ConsolaCustom.Singleton();
            var color = ConsoleColor.Yellow;
            var msgVelMax = "Ingrese la velocidad maxima : ";
            float velocidadMaxima = consola.LeerEntero(1, null, msgVelMax, color);
            Robot robot = fabricaRobot.Crear(velocidadMaxima, Cuartel);
            if(!Cuartel.AgregarRobot(robot))
                ConsolaCustom.Singleton().Imprimir("\nEl robot ya pertenece al cuartel\n", ConsoleColor.Red);
        }
    }
}