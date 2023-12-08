using Backend.Localizaciones;

namespace FrontEnd.MenuNamespace.MenuCuartelNamespace
{
    public class MenuCuartel : MenuConsola
    {
        private Cuartel Cuartel { get; }

        public MenuCuartel(Cuartel cuartel)
            : base("Gestionar " + cuartel.NombreTerreno)
        {
            Cuartel = cuartel;
        }

        public void Ejecutar()
        {
        }
    }
}