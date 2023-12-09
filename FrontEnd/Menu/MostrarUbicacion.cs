using Backend.Localizaciones;
using FrontEnd.MenuNamespace;
using System.Text;

namespace FrontEnd.Menu
{
    public class MostrarUbicacion : ICommand
    {
        private Localizacion2D localizacion;

        public MostrarUbicacion(Localizacion2D localizacion)
        {
            this.localizacion = localizacion;
        }

        public void Ejecutar()
        {
            var consola = ConsolaCustom.Singleton();
            consola.Imprimir(new StringBuilder()
                .Append("\nLocalizacion de ")
                .Append(localizacion.NombreTerreno)
                .Append(": (")
                .Append(localizacion.X)
                .Append(",")
                .Append(localizacion.Y)
                .Append(")\n")
                .ToString()
                , ConsoleColor.Blue
            );
        }

        public override string ToString()
        {
            return "Mostrar ubicacion.";
        }
    }
}
