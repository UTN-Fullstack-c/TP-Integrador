using Backend.Localizaciones;
using FrontEnd.MenuNamespace;

namespace FrontEnd.Menu.MenuCuartelNamespace.MovilizarVarios
{
    public class RepararTodos : ICommand
    {
        private Cuartel Cuartel;

        public RepararTodos(Cuartel cuartel)
        {
            Cuartel = cuartel;
        }

        public void Ejecutar()
        {
            Cuartel.RepararTodos();
        }
        public override string ToString()
        {
            return "Traer al cuartel a todos los robots que necesiten reparacion y arreglarlos.";
        }
    }
}
