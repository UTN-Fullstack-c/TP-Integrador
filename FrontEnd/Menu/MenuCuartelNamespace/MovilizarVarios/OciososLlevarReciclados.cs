using Backend.Localizaciones;
using FrontEnd.MenuNamespace;

namespace FrontEnd.Menu.MenuCuartelNamespace.MovilizarVarios
{
    public class OciososLlevarReciclados : ICommand
    {
        private Cuartel Cuartel { get; }

        public OciososLlevarReciclados(Cuartel cuartel)
        {
            Cuartel = cuartel;
        }

        public void Ejecutar()
        {
            Cuartel.OciososLLevarReciclados();
        }

        public override string ToString()
        {
            return "Los robots ociosos deben llevar el maximo de carga desde el vertedero hacia el punto de reciclaje mas cercanos.";
        }
    }
}