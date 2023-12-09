using Backend.Localizaciones;
using Backend.Robots;
using FrontEnd.MenuNamespace;

namespace FrontEnd.Menu.MenuCuartelNamespace.MenuRobotNamespace
{
    public class RegresarCuartel : ICommand
    {
        private Robot Robot;

        public RegresarCuartel(Robot robot)
        {
            Robot = robot;
        }

        public void Ejecutar()
        {
            Robot.Cuartel.Recall(Robot);
            var consola = ConsolaCustom.Singleton();
            if (consola.LeerBooleano("Quiere cargar la bateria del robot?"))
                Robot.Cuartel.CargarBateria(Robot);
            if (consola.LeerBooleano("Quiere dejar toda la carga en el cuartel?"))
                Robot.Cuartel.RecibirCargamento(Robot);
        }

        public override string ToString()
        {
            return "Regresar al cuartel.";
        }
    }
}
