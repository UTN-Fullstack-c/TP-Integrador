using Backend.Localizaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class ControladorMovimientoIterativo
    {
        public static List<Localizacion2D> RutaOptima(Mapa mapa, Localizacion2D inicio, Localizacion2D destino)
        {
            var tiposEvitar = new List<string> { "Lago", "Vertedero Electronico", "Vertedero" };
            return TodosLosCaminos(mapa, inicio, destino, tiposEvitar).FirstOrDefault();
        }

        public static List<Localizacion2D> RutaDirecta(Mapa mapa, Localizacion2D inicio, Localizacion2D destino)
        {
            var tiposEvitar = new List<string> { "Lago" };
            return TodosLosCaminos(mapa, inicio, destino, tiposEvitar).FirstOrDefault();
        }

        public static List<List<Localizacion2D>> RutaOptima2(Mapa mapa, Localizacion2D inicio, Localizacion2D destino)
        {
            var tiposEvitar = new List<string> { "Lago", "Vertedero Electronico", "Vertedero" };
            return TodosLosCaminos2(mapa, inicio, destino, tiposEvitar);
        }

        public static List<List<Localizacion2D>> RutaDirecta2(Mapa mapa, Localizacion2D inicio, Localizacion2D destino)
        {
            var tiposEvitar = new List<string> { "Lago" };
            return TodosLosCaminos2(mapa, inicio, destino, tiposEvitar);
        }

        private static List<List<Localizacion2D>> TodosLosCaminos(Mapa mapa, Localizacion2D inicio, Localizacion2D destino, List<string> tiposEvitar)
        {
            var caminos = new List<List<Localizacion2D>>();
            EncontrarCaminos(mapa, inicio, destino, tiposEvitar, new List<Localizacion2D>(), caminos);
            return caminos;
        }

        private static List<List<Localizacion2D>> TodosLosCaminos2(Mapa mapa, Localizacion2D inicio, Localizacion2D destino, List<string> tiposEvitar)
        {
            var caminos = new List<List<Localizacion2D>>();
            EncontrarCaminos(mapa, inicio, destino, tiposEvitar, new List<Localizacion2D>(), caminos);
            return caminos;
        }

        private static void EncontrarCaminos(Mapa mapa, Localizacion2D actual, Localizacion2D destino, List<string> tiposEvitar, List<Localizacion2D> camino, List<List<Localizacion2D>> caminos)
        {
            camino.Add(actual);

            if (actual.Equals(destino))
            {
                caminos.Add(new List<Localizacion2D>(camino));
            }
            else
            {
                var vecinos = ObtenerVecinos(mapa, actual, tiposEvitar);

                foreach (var vecino in vecinos.Where(v => !camino.Contains(v)))
                {
                    EncontrarCaminos(mapa, vecino, destino, tiposEvitar, camino, caminos);
                }
            }

            camino.RemoveAt(camino.Count - 1);
        }

        private static List<Localizacion2D> ObtenerVecinos(Mapa mapa, Localizacion2D localizacion, List<string> tiposEvitar)
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

        private static void AgregarVecino(Mapa mapa, List<Localizacion2D> vecinos, int x, int y, List<string> tiposEvitar)
        {
            if (x >= 0 && x < mapa.LargoHorizontal() && y >= 0 && y < mapa.LargoVertical())
            {
                Localizacion2D vecino = mapa.Get(x, y);
                if (!tiposEvitar.Contains(vecino.NombreTerreno))
                {
                    vecinos.Add(vecino);
                }
            }
        }
    }
}
