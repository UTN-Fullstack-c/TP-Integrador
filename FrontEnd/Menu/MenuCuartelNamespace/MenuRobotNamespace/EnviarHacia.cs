using Backend.Localizaciones;
using Backend.Robots;
using FrontEnd.MapaNamespace;
using FrontEnd.MenuNamespace;
namespace FrontEnd.Menu.MenuCuartelNamespace.MenuRobotNamespace
{
    public class EnviarHacia : ICommand
    {
        private Robot Robot;

        public EnviarHacia(Robot robot)
        {
            Robot = robot;
        }

        public void Ejecutar()
        {
            var consola = ConsolaCustom.Singleton();
            Mapa mapa = MapaConsola.Singleton().Mapa;
            int x = consola.LeerEntero(
                0,
                mapa.LargoHorizontal(),
                "Latitud (X) del destino: ",
                ConsoleColor.White
            );
            int y = consola.LeerEntero(
                0,
                mapa.LargoVertical(),
                "Longitud (Y) del destino: ",
                ConsoleColor.White
            );
            Robot.Cuartel.Enviar(Robot, mapa.Get(x,y));
        }

        public override string ToString()
        {
            return "Enviar hacia un punto especifico del mapa.";
        }
    }
}
