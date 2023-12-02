namespace Backend.Localizaciones
{
    public class Localizacion3D : Localizacion2D
    {
        public int Z { get; set; }

        public Localizacion3D(int x, int y, int z) : base(x, y, "Localizacion3D")
        {
            Z = z;
        }
    }
}
