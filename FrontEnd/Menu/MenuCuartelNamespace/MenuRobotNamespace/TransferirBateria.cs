using Backend.Robots;
using FrontEnd.MenuNamespace;
using System.Text;

namespace FrontEnd.Menu.MenuCuartelNamespace.MenuRobotNamespace
{
    public class TransferirBateria : ICommand
    {
        private Robot robotOrigen;
        private Robot robotDestino;

        public TransferirBateria(Robot robotDestino, Robot robotOrigen)
        {
            this.robotDestino = robotDestino;
            this.robotOrigen = robotOrigen;
        }
        public void Ejecutar()
        {
            var consola = ConsolaCustom.Singleton();
            robotOrigen.TransferirBateria(robotDestino);
            consola.Imprimir(new StringBuilder()
                .Append("\nBateria de ")
                .Append(robotOrigen.GetNombre())
                .Append(": ")
                .Append(robotOrigen.Bateria.PorcentajeActual())
                .Append("%\n")
                .Append("Bateria de ")
                .Append(robotDestino.GetNombre())
                .Append(": ")
                .Append(robotDestino.Bateria.PorcentajeActual())
                .Append("%\n")
                .ToString()
            );
        }
    }
}
