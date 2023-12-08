
namespace FrontEnd.CustomException
{
    public class TipoProductoInvalido : Exception
    {
        private const string DESCRIPCION = "El usuario decidio no completar la operacion. ";

        public TipoProductoInvalido(string mensaje) 
            : base(DESCRIPCION + mensaje)
        { }
    }
}
