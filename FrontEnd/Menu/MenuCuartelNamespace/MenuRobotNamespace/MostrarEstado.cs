using Backend.Robots;
using FrontEnd.MenuNamespace;

namespace FrontEnd.Menu.MenuCuartelNamespace.MenuRobotNamespace
{
    public class MostrarEstado : ICommand
    {
        private Robot Robot;

        public MostrarEstado(Robot robot)
        {
            Robot = robot;
        }

        public void Ejecutar()
        {
            var consola = ConsolaCustom.Singleton();
            consola.Imprimir("\n" + Robot.ToString() + "\n");
        }

        public override string ToString()
        {
            return "Mostrar estado del robot";
        }
    }
}
