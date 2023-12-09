using Backend.Robots;
using FrontEnd.MenuNamespace;
using System.Text;

namespace FrontEnd.Menu.MenuCuartelNamespace.MenuRobotNamespace
{
    public class TransferirCargaFisica : ICommand
    {
        private Robot robotOrigen;
        private Robot robotDestino;

        public TransferirCargaFisica(Robot robotDestino, Robot robotOrigen)
        {
            this.robotDestino = robotDestino;
            this.robotOrigen = robotOrigen;
        }
        public void Ejecutar()
        {
            var consola = ConsolaCustom.Singleton();
            robotOrigen.TransferirCargaFisica(robotDestino);
            consola.Imprimir(new StringBuilder()
                .Append("\nCapacidad del contenedor de ")
                .Append(robotOrigen.GetNombre())
                .Append(": ")
                .Append(robotOrigen.Contenedor.PorcentajeActual())
                .Append("%\n")
                .Append("Capacidad del contenedor de ")
                .Append(robotDestino.GetNombre())
                .Append(": ")
                .Append(robotDestino.Contenedor.PorcentajeActual())
                .Append("%\n")
                .ToString()
            );
        }
    }
}
