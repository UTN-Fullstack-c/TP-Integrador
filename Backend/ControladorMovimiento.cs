using Backend.Localizaciones;
using Backend.Robots;

namespace Backend
{
    public class ControladorMovimiento
    {
        private Mapa mapa;

        public ControladorMovimiento(Mapa mapa)
        {
            this.mapa = mapa;
        }










        public static List<Localizacion2D> RutaOptima(Mapa mapa, Localizacion2D inicio, Localizacion2D destino)
        {
            var tiposEvitar = new List<string> { "Lago", "Vertedero Electronico", "Vertedero" };
            return TodosLosCaminos(mapa, inicio, destino, tiposEvitar);
        }

        public static List<List<Localizacion2D>> RutaOptima2(Mapa mapa, Localizacion2D inicio, Localizacion2D destino)
        {
            var tiposEvitar = new List<string> { "Lago", "Vertedero Electronico", "Vertedero" };
            return TodosLosCaminos2(mapa, inicio, destino, tiposEvitar);
        }

        public static List<Localizacion2D> RutaDirecta(Mapa mapa, Localizacion2D inicio, Localizacion2D destino)
        {
            var tiposEvitar = new List<string> { "Lago" };
            return TodosLosCaminos(mapa, inicio, destino, tiposEvitar);
        }

        public static List<List<Localizacion2D>> RutaDirecta2(Mapa mapa, Localizacion2D inicio, Localizacion2D destino)
        {
            var tiposEvitar = new List<string> { "Lago" };
            return TodosLosCaminos2(mapa, inicio, destino, tiposEvitar);
        }

        public static List<Localizacion2D> TodosLosCaminos(Mapa mapa, Localizacion2D inicio, Localizacion2D destino, List<string> tiposEvitar)
        {
            List<Localizacion2D> camino = new List<Localizacion2D>();
            List<Localizacion2D> mejorCamino = new List<Localizacion2D>();
            List<List<Localizacion2D>> caminos = new List<List<Localizacion2D>>();
            TodosLosCaminosRecursiva(inicio, destino, camino, mejorCamino, caminos, mapa, tiposEvitar);
            inicio.Marca = 0;
            return mejorCamino;
        }

        public static List<List<Localizacion2D>> TodosLosCaminos2(Mapa mapa, Localizacion2D inicio, Localizacion2D destino, List<string> tiposEvitar)
        {
            List<Localizacion2D> camino = new List<Localizacion2D>();
            List<Localizacion2D> mejorCamino = new List<Localizacion2D>();
            List<List<Localizacion2D>> caminos = new List<List<Localizacion2D>>();
            TodosLosCaminosRecursiva(inicio, destino, camino, mejorCamino, caminos, mapa, tiposEvitar);
            inicio.Marca = 0;
            return caminos;
        }


        public static void TodosLosCaminosRecursiva(
            Localizacion2D origen, 
            Localizacion2D destino, 
            List<Localizacion2D> camino,
            List<Localizacion2D> mejorCamino,
            List<List<Localizacion2D>> caminos,
            Mapa mapa,
            List<string> tiposEvitar
            )
        {
            origen.Marca = 1;
            camino.Add(origen);
            if (origen.Equals(destino))
            {
                List<Localizacion2D> nuevoCamino = new List<Localizacion2D>();
                foreach (var localizacion in camino)
                    nuevoCamino.Add(localizacion);
                if (camino.Count < mejorCamino.Count || mejorCamino.Count == 0)
                {
                    mejorCamino.Clear();
                    foreach (var localizacion in camino)
                        mejorCamino.Add(localizacion);
                }
                caminos.Add(nuevoCamino);
            }
            else
            {
                List<Localizacion2D> vecinos = ObtenerVecinos(mapa, origen, tiposEvitar);
                foreach (var vecino in vecinos)
                {
                    if (vecino.Marca == 0)
                    {
                        TodosLosCaminosRecursiva(
                            vecino,
                            destino,
                            camino,
                            mejorCamino,
                            caminos,
                            mapa,
                            tiposEvitar
                        );
                        vecino.Marca = 0;
                        camino.RemoveAt(camino.Count - 1);
                    }
                }
            }
        }

        private static List<Localizacion2D> ObtenerVecinos(Mapa mapa, Localizacion2D localizacion, List<string> tiposEvitar)
        {
            List<Localizacion2D> vecinos = new List<Localizacion2D>();

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
                if (vecino.Marca == 0 && !tiposEvitar.Contains(vecino.NombreTerreno))
                {
                    vecinos.Add(vecino);
                }
            }
        }


















        public static List<List<Localizacion2D>> EncontrarRutas(Mapa mapa, Localizacion2D inicio, Localizacion2D destino, List<string> tiposEvitar)
        {
            List<List<Localizacion2D>> rutas = new List<List<Localizacion2D>>();
            Queue<List<Localizacion2D>> queue = new Queue<List<Localizacion2D>>();
            HashSet<Localizacion2D> visitado = new HashSet<Localizacion2D>();

            queue.Enqueue(new List<Localizacion2D> { inicio });

            while (queue.Count > 0)
            {
                List<Localizacion2D> rutaActual = queue.Dequeue();
                Localizacion2D ultimaLocalizacion = rutaActual.Last();

                if (ultimaLocalizacion.Equals(destino))
                {
                    rutas.Add(rutaActual);
                    // No detener la búsqueda, seguir explorando para encontrar más rutas
                }

                foreach (var vecino in ObtenerVecinos(mapa, ultimaLocalizacion, tiposEvitar))
                {
                    if (!visitado.Contains(vecino))
                    {
                        visitado.Add(vecino);
                        List<Localizacion2D> nuevaRuta = new List<Localizacion2D>(rutaActual);
                        nuevaRuta.Add(vecino);
                        queue.Enqueue(nuevaRuta);
                    }
                }
            }

            return rutas;
        }



        public void RecorrerRutaDirecta(
            Robot robot, 
            Localizacion2D destino,
            List<Localizacion2D> recorrido
            )
        {
            Localizacion2D origen = robot.Localizacion;
            recorrido.Add( origen );
            int dx = GetDireccion(origen.X, destino.X);
            int dy = GetDireccion(origen.Y, destino.Y);
            int movimientoHorizontal = dx;
            int movimientoVertical = dy;
            int distanciaHorizontal = (destino.X - origen.X) * dx;
            int distanciaVertical = (destino.Y - origen.Y) * dy;
            
            int restoX = 0;
            int restoY = 0;

            if(distanciaHorizontal == 0)
                RecorridoVertical(robot, destino, recorrido);
            else if (distanciaVertical == 0)
                RecorridoHorizontal(robot, destino, recorrido);
            else if ( distanciaHorizontal > distanciaVertical )
            {
                movimientoHorizontal *= (int)(distanciaHorizontal / distanciaVertical);
                restoX = distanciaHorizontal % distanciaVertical;
            }
            else
            {
                movimientoVertical *= (int)(distanciaVertical / distanciaHorizontal); 
                restoY = distanciaVertical % distanciaHorizontal;   
            }
            int x = 0;
            int y = 0;
            while(
                destino.X != origen.X && 
                destino.Y != origen.Y
                )
            {
                y = origen.Y + restoY * dy;
                x = origen.X;
                if (restoY == 0)
                    x = origen.X + movimientoHorizontal + restoX * dx;
                restoY = 0; 
                restoX = 0;
                if (x == destino.X)
                {
                    origen = MoverRobot(robot, x, y, recorrido);
                    origen = RecorridoVertical(robot, destino, recorrido);
                }
                else
                {
                    origen = MoverRobot(robot, x, y, recorrido);
                    y += movimientoVertical;
                    if (y == 27)
                        ;
                    if (y == destino.Y)
                    {
                        origen = MoverRobot(robot, x, y, recorrido);
                        origen = RecorridoHorizontal(robot, destino, recorrido);
                    }
                    else
                        origen = MoverRobot(robot, x, y, recorrido);
                }
            }
            
        }

        private int GetDireccion(
            int origen, 
            int destino
            )
        {
            int direccion = 0;
            if (origen > destino)
                direccion = -1;
            else if (origen < destino)
                direccion = 1;
            return direccion;
        }

        private Localizacion2D MoverRobot(
            Robot robot, 
            int x, 
            int y,
            List<Localizacion2D> recorrido
            ) 
        {
            Localizacion2D destino = mapa.Get(x, y);
            int direccion = GetDireccion(robot.Localizacion.X, destino.X);
            if(direccion != 0)
                for (int i = robot.Localizacion.X + direccion; i * direccion <= x * direccion; i += direccion)
                {
                    Localizacion2D paso = mapa.Get(i, y);
                    paso.Hospedar(robot);
                    recorrido.Add(paso);
                }
            direccion = GetDireccion(robot.Localizacion.Y, destino.Y);
            if(direccion != 0)
                for (int i = robot.Localizacion.Y + direccion; i * direccion <= y * direccion; i += direccion)
                {
                    Localizacion2D paso = mapa.Get(x, i);
                    paso.Hospedar(robot);
                    recorrido.Add(paso);
                }
            return destino;
        }

        private Localizacion2D RecorridoVertical(
            Robot robot, 
            Localizacion2D destino,
            List<Localizacion2D> recorrido
            )
        {
            Localizacion2D origen = robot.Localizacion;
            int direccionVertical = GetDireccion(origen.Y, destino.Y);
            while (destino.Y != origen.Y)
            {
                int y = origen.Y + direccionVertical;
                origen = MoverRobot(robot, origen.X, y, recorrido);
            }
            return origen;
        }

        private Localizacion2D RecorridoHorizontal(
            Robot robot, 
            Localizacion2D destino,
            List<Localizacion2D> recorrido
            )
        {
            Localizacion2D origen = robot.Localizacion;
            int direccionHorizontal = GetDireccion(origen.X, destino.X);
            while (destino.X != origen.X)
            {
                int x = origen.X + direccionHorizontal;
                origen = MoverRobot(robot, x, origen.Y, recorrido);
            }
            return origen;
        }
    }
}
