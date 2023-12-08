using Backend.Localizaciones;
using Backend.Robots;

namespace FrontEnd.MapaNamespace
{
    public class LocalizacionDestacada : Localizacion2D
    {
        public Localizacion2D Localizacion { get; set; }
        public ConsoleColor Color { get; set; }
        public override string NombreTerreno
        {
            get { return Localizacion.NombreTerreno; }
            set { Localizacion.NombreTerreno = value; }
        }
        public override int X { get { return Localizacion.X; } }
        public override int Y { get { return Localizacion.Y; } }
        public override int? Marca
        {
            get { return Localizacion.Marca; }
            set { Localizacion.Marca = value; }
        }

        public LocalizacionDestacada(
            Localizacion2D localizacion,
            ConsoleColor color
            )
        {
            Color = color;
            Localizacion = localizacion;
        }

        public override bool Hospedar(Robot robot)
        {
            return Localizacion.Hospedar(robot);
        }
    }
}
