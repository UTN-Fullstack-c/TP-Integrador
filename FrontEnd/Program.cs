using Backend;
using Backend.Localizaciones;
using Backend.Robots;

namespace FrontEnd
{
    internal class Program
    {
        private const int Y_MAP_LENGTH = 30;
        private const int X_MAP_LENGTH = 100;
        private const int MAX_CUARTELES = 3;
        private const int MAX_RECICLAJE = 5;
        static void Main(string[] args)
        {
            Mapa mapa = new Mapa(
                X_MAP_LENGTH, 
                Y_MAP_LENGTH,
                MAX_CUARTELES,
                MAX_RECICLAJE
            );
            MapaConsola mapaConsola = new MapaConsola(mapa);
            var fabrica = new FabricaRobot();
            Localizacion2D origen = mapa.Get(50, 15);
            Robot m8 = fabrica.CreateM8(
                100,
                1,
                origen
            );
            mapaConsola.Imprimir();
            Console.WriteLine();
            Console.ReadKey();
            Cuartel cuartel = mapa.Cuarteles[0];
            cuartel.Mapa = mapa;
            cuartel.Suscriptors.Add((message) =>
            {
                Console.WriteLine(message);
                mapaConsola.Imprimir(false);
                Console.WriteLine(m8);
                Console.ReadKey();
            });
            cuartel.AgregarRobot( m8 );
            cuartel.TodosLosRobotsAlTrabajo();
            Console.WriteLine(" ");
            mapaConsola.Imprimir(false);
            Console.WriteLine(m8);
            Console.ReadLine();
            if (!cuartel.RepararTodos())
                Console.WriteLine("Hay robots que no pueden llegar al cuartel para reparase");
            else
            {
                Console.WriteLine();
                mapaConsola.Imprimir(false);
                Console.WriteLine(m8);
            }
            
            Localizacion2D destino = mapa.Get(X_MAP_LENGTH - 1, Y_MAP_LENGTH - 1);

            Console.WriteLine("Mapa");
            mapaConsola.Imprimir(false); 
            
            var ruta = GeneradorRuta.RutaOptima(mapa, origen, destino);
            string msg = "";
            if (ruta.Count == 0) 
                msg = " inexistente";
            Console.WriteLine("Ruta Optima" + msg);
            for (int i = 0; i < ruta.Count; i++)
                ruta[i].Marca = i % 9;
            mapaConsola.Imprimir(ruta, false);
            
            msg = "";
            if (ruta.Count == 0)
                msg = " inexistente";
            Console.WriteLine("Ruta Directa" + msg);
            ruta = GeneradorRuta.RutaDirecta(mapa, origen, destino);
            for (int i = 0; i < ruta.Count; i++)
                ruta[i].Marca = i % 9;
            mapaConsola.Imprimir(ruta, false);
            
            Console.ReadKey();
            /*
            var rutas = ControladorMovimientoBfs.RutaOptima2(mapa, origen, destino);
            //mapaConsola.Imprimir(ruta);
            Console.WriteLine("Rutas directas : " + rutas.Count);
            //Console.ReadKey();
            foreach (var r in rutas)
            {
                mapaConsola.Imprimir(false  );
                for (int i = 0; i < r.Count; i++)
                    r[i].Marca = i%9;
                mapaConsola.Imprimir(r);
                Console.ReadKey();
            }*/
            /*         rutas = ControladorMovimiento.RutaDirecta(mapa, origen, destino);
                     Console.WriteLine("Rutas directas : " + rutas.Count);
                     Console.ReadKey();
                     foreach (var ruta in rutas)
                     {
                         mapaConsola.Imprimir(ruta, true, ConsoleColor.DarkMagenta);
                         Console.ReadKey();
                     }*/
            /*
            List<Localizacion2D> recorrido = new List<Localizacion2D>();
            Localizacion2D destino = mapa.Get(1,1);
            int option = 1;
            switch(option)
            {
                case 1:
                    controladorMovimiento.RecorrerRutaDirecta(uav, destino, recorrido);
                    mapaConsola.Imprimir(recorrido);
                    break;
                case 2:
                    mapaConsola.Imprimir();
                    break;
                case 3:
                    recorrido.Add(new Cuartel(X_MAP_LENGTH - 1, Y_MAP_LENGTH -1));
                    mapaConsola.Imprimir(recorrido);
                    break;
            }
            */
        }
    }
}