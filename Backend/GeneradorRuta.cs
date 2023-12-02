using Backend.Localizaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class GeneradorRuta
    {
        public static List<Localizacion2D> RutaOptima(
            Mapa mapa, 
            Localizacion2D inicio, 
            Localizacion2D destino
            )
        {
            var tiposEvitar = new List<string> { "Lago", "Vertedero Electronico", "Vertedero" };
            return EncontrarCamino(mapa, inicio, destino, tiposEvitar);
        }

        public static List<Localizacion2D> RutaDirecta(Mapa mapa, Localizacion2D inicio, Localizacion2D destino)
        {
            var tiposEvitar = new List<string> { "Lago" };
            return EncontrarCamino(mapa, inicio, destino, tiposEvitar);
        }

        private static List<Localizacion2D> EncontrarCamino(
            Mapa mapa, 
            Localizacion2D inicio, 
            Localizacion2D destino, 
            List<string> tiposEvitar
            )
        {
            var cola = new Queue<Localizacion2D>();
            var visitados = new HashSet<Localizacion2D>();
            var padres = new Dictionary<Localizacion2D, Localizacion2D>();

            cola.Enqueue(inicio);
            visitados.Add(inicio);

            while (cola.Count > 0)
            {
                var actual = cola.Dequeue();

                if (actual.Equals(destino))
                    return ReconstruirCamino(padres, actual);

                var vecinos = ObtenerVecinos(mapa, actual, tiposEvitar);
                var noVisitados = vecinos.Where(v => !visitados.Contains(v));

                foreach (var vecino in noVisitados)
                {
                    visitados.Add(vecino);
                    padres[vecino] = actual;
                    cola.Enqueue(vecino);
                }
            }

            return new List<Localizacion2D>();
        }

        private static List<Localizacion2D> ReconstruirCamino(
            Dictionary<Localizacion2D, Localizacion2D> padres, 
            Localizacion2D destino
            )
        {
            var camino = new List<Localizacion2D>();
            var actual = destino;

            while (actual != null)
            {
                camino.Add(actual);
                padres.TryGetValue(actual, out actual);
            }

            camino.Reverse();
            return camino;
        }

        private static List<Localizacion2D> ObtenerVecinos(
            Mapa mapa,
            Localizacion2D localizacion, 
            List<string> tiposEvitar
            )
        {
            var vecinos = new List<Localizacion2D>();

            int x = localizacion.X;
            int y = localizacion.Y;

            AgregarVecino(mapa, vecinos, x - 1, y, tiposEvitar);
            AgregarVecino(mapa, vecinos, x + 1, y, tiposEvitar);
            AgregarVecino(mapa, vecinos, x, y - 1, tiposEvitar);
            AgregarVecino(mapa, vecinos, x, y + 1, tiposEvitar);

            return vecinos;
        }

        private static void AgregarVecino(
            Mapa mapa, 
            List<Localizacion2D> vecinos, 
            int x, 
            int y, 
            List<string> tiposEvitar
            )
        {
            if (
                x >= 0 && x < mapa.LargoHorizontal() && 
                y >= 0 && y < mapa.LargoVertical()
                )
            {
                Localizacion2D vecino = mapa.Get(x, y);
                if (!tiposEvitar.Contains(vecino.NombreTerreno))
                    vecinos.Add(vecino);
            }
        }
    }
}
