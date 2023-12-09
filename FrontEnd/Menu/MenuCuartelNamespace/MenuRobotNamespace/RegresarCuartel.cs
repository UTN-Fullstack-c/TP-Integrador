using Backend.Localizaciones;
using Backend.Robots;
using FrontEnd.MenuNamespace;

namespace FrontEnd.Menu.MenuCuartelNamespace.MenuRobotNamespace
{
    public class RegresarCuartel : ICommand
    {
        private Cuartel Cuartel;
        private Robot Robot;

        public RegresarCuartel(Cuartel cuartel, Robot robot)
        {
            Cuartel = cuartel;
            Robot = robot;
        }

        public void Ejecutar()
        {
            Cuartel.Recall(Robot);
        }

        public override string ToString()
        {
            return "Regresar al cuartel.";
        }
    }
}
