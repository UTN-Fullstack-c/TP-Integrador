using Backend.Localizaciones.Fabricas.Edificio;
using Backend.Localizaciones.Fabricas.Zona;

namespace Backend.Localizaciones
{
    public class Mapa
    {
        private Localizacion2D[,] mapa;
        public List<Cuartel> Cuarteles { get; set; }
        public List<Reciclaje> Reciclajes { get; set; }

        public List<Vertedero> Vertederos { get; set; }
        public List<VertederoElectronico> VertederoElectronicos { get; set; }

        private Mapa() 
        {
            Cuarteles = new List<Cuartel>();
            Reciclajes = new List<Reciclaje>();
            Vertederos = new List<Vertedero>();
            VertederoElectronicos = new List<VertederoElectronico>();
        }

        public Mapa(
            int xLength,
            int yLength,
            int maxCantCuarteles,
            int maxCantPuntosRecicleje
            )
        {
            Cuarteles = new List<Cuartel>();
            Reciclajes = new List<Reciclaje>();
            Vertederos = new List<Vertedero>();
            VertederoElectronicos = new List<VertederoElectronico>();
            var probabilidades = new List<int>() { 5,5,12, 50 };
            GenerarMapaAleatorio(
                yLength,
                xLength,
                maxCantCuarteles,
                maxCantPuntosRecicleje,
                probabilidades
            );
        }

        public Localizacion2D Get(int x, int y)
        {
            return mapa[x, y];
        }

        public int LargoVertical()
        {
            return mapa.GetLength(1);
        }

        public int LargoHorizontal()
        {
            return mapa.GetLength(0);
        }

        private void GenerarMapaAleatorio(
            int yLength,
            int xLength,
            int maxCantCuarteles,
            int maxCantPuntosRecicleje,
            List<int> probabilidades
            )
        {
            validarProbabilidades(probabilidades);
            mapa = new Localizacion2D[xLength, yLength];
            Random random = new Random();

            for (int x = 0; x < mapa.GetLength(0); x++)
            {
                for (int y = 0; y < mapa.GetLength(1); y++)
                {
                    int probabilidad = random.Next(100);
                    int i = 0;
                    int acumulado = 0;
                    while (
                        i < probabilidades.Count && 
                        probabilidad > acumulado
                        )
                    {
                        acumulado += probabilidades[i++];
                    }
                    mapa[x, y] = FabricaDeZonas.Crear(i-1, x, y);
                    guardarZonaDestacada(mapa[x, y]);
                }
            }
            construirZona(new FabricaCuartel(), maxCantCuarteles);
            construirZona(new FabricaReciclaje(), maxCantPuntosRecicleje);
        }

        public void validarProbabilidades(List<int> probabilidades)
        {
            int acumulado = 0;
            foreach (int p in probabilidades)
                acumulado += p;
            if (acumulado > 100)
                throw new Exception("La suma de probabilidades deberia ser 100 (se acepta < 100)");
        }

        public void construirZona<TipoZona>(
            FabricaDeEdificios<TipoZona> fabricaDeZonas,
            int maxAmount
            )
            where TipoZona : Localizacion2D
        {
            Random random = new Random();
            int contadorCuarteles = random.Next(maxAmount) + 1;
            while (--contadorCuarteles >= 0)
            {
                int x = random.Next(mapa.GetLength(0));
                int y = random.Next(mapa.GetLength(1));
                mapa[x, y] = fabricaDeZonas.Crear(x, y, contadorCuarteles);
                guardarZonaDestacada(mapa[x,y]);   
            }
        }

        public void guardarZonaDestacada<TipoZona>(TipoZona zona)
            where TipoZona : Localizacion2D
        {
            if (zona is Cuartel)
                Cuarteles.Add(zona as Cuartel);
            else if (zona is Reciclaje)
                Reciclajes.Add(zona as Reciclaje);
            if (zona is Vertedero)
                Vertederos.Add(zona as Vertedero);
            else if (zona is VertederoElectronico)
                VertederoElectronicos.Add(zona as VertederoElectronico);
        }

        public void modificarZona<TipoZona>(
            TipoZona zona
            )
            where TipoZona : Localizacion2D
        {
            mapa[zona.X, zona.Y] = zona;
        }
    }
}
