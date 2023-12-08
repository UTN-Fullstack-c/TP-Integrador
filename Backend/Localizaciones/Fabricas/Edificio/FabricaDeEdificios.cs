
namespace Backend.Localizaciones.Fabricas.Edificio
{
    public abstract class FabricaDeEdificios<T> where T : Localizacion2D
    {
        public static Localizacion2D Crear(int tipo, int x, int y, int numeroDeEdificio)
        {
            switch (tipo)
            {
                case 0:
                    return new FabricaCuartel().Crear(x, y, numeroDeEdificio);
                case 1:
                    return new FabricaReciclaje().Crear(x, y, numeroDeEdificio);
            }
            throw new Exception("tipo invalido");
        }

        public abstract T Crear(int x, int y, int numeroDeEdificio);
    }
}
