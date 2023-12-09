using Backend.Localizaciones;
using FrontEnd.MenuNamespace;
using System.Text;

namespace FrontEnd.Menu.MenuCuartelNamespace
{
    public class MostrarUbicacion : ICommand
    {
        public Localizable localizable { get; set; }

        public MostrarUbicacion(Localizable localizacion)
        {
            this.localizable = localizacion;
        }

        public void Ejecutar()
        {
            var consola = ConsolaCustom.Singleton();
            Localizacion2D localizacion = localizable.GetLocalizacion();
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
