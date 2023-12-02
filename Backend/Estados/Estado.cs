namespace Backend.Estados
{
    public abstract class Estado
    {
        public string Nombre { get; }

        protected Estado(string nombre)
        {
            Nombre = nombre;
        }
    }
}
