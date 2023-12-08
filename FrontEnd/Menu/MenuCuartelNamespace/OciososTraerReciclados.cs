using Backend.Localizaciones;

namespace FrontEnd.MenuNamespace.MenuCuartelNamespace
{
    public class OciososTraerReciclados : ICommand
    {
        private Cuartel Cuartel { get; }

        public OciososTraerReciclados(Cuartel cuartel)
        {
            Cuartel = cuartel;
        }

        public void Ejecutar()
        {

        }

        public override string ToString()
        {
            return "Los robots ociosos deben llevar el maximo de carga desde el vertedero hacia el punto de reciclaje mas cercanos.";
        }
    }
}