using Backend.Localizaciones;
using FrontEnd.MenuNamespace;

namespace FrontEnd.Menu.MenuCuartelNamespace.MovilizarVarios
{
    public class Recall : ICommand
    {
        private Cuartel Cuartel;

        public Recall(Cuartel cuartel)
        {
            Cuartel = cuartel;
        }

        public void Ejecutar()
        {
            Cuartel.Recall();
        }
        public override string ToString()
        {
            return "Recall";
        }
    }
}
