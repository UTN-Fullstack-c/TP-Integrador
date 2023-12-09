using Backend;
using Backend.Localizaciones;
using Backend.Robots;
using Backend.Robots.FabricaRobots;
using FrontEnd.MapaNamespace;
using FrontEnd.Menu;
using FrontEnd.MenuNamespace;
using FrontEnd.MenuNamespace.MenuMapaNamespace;
using System.Text;

namespace FrontEnd
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ImprimirCaratula();
            Mapa mapa = CargarMapa();
            if(mapa != null) 
            {
                MenuConsola menuCuarteles = new MenuPrincipal();
                menuCuarteles.Ejecutar();
            }

            //function();
        }

        public static Mapa CargarMapa()
        {
            var menuMapas = new MenuMapa();
            menuMapas.Ejecutar();
            return MapaConsola.Singleton().Mapa!;
        }

        static void function()
        {
            MapaConsola mapaConsola = MapaConsola.Singleton();
            Mapa mapa = mapaConsola.Mapa;
            var fabrica = new FabricaM8();
            Localizacion2D origen = mapa.Get(50, 15);
            Robot m8 = fabrica.Crear(
                100,
                origen
            );
            mapaConsola.Imprimir();
            Console.WriteLine();
            Console.ReadKey();
            Cuartel cuartel = mapa.Cuarteles[0];
            //cuartel.Mapa = mapa;
            cuartel.Suscriptors.Add((message) =>
            {
                Console.WriteLine(message);
                mapaConsola.Imprimir();
                Console.WriteLine(m8);
                Console.ReadKey();
            });
            cuartel.AgregarRobot( m8 );
            cuartel.OciososLLevarReciclados();
            Console.WriteLine(" ");
            mapaConsola.Imprimir();
            Console.WriteLine(m8);
            Console.ReadLine();
            if (!cuartel.RepararTodos())
                Console.WriteLine("Hay robots que no pueden llegar al cuartel para reparase");
            else
            {
                Console.WriteLine();
                mapaConsola.Imprimir();
                Console.WriteLine(m8);
            }
            
            Localizacion2D destino = mapa.Get(mapa.LargoHorizontal() - 1, mapa.LargoVertical() - 1);

            Console.WriteLine("Mapa");
            mapaConsola.Imprimir(); 
            
            var ruta = GeneradorRuta.RutaOptima(mapa, origen, destino);
            string msg = "";
            if (ruta.Count == 0) 
                msg = " inexistente";
            Console.WriteLine("Ruta Optima" + msg);
            for (int i = 0; i < ruta.Count; i++)
                ruta[i].Marca = i % 9;
            mapaConsola.Imprimir(ruta);
            
            msg = "";
            if (ruta.Count == 0)
                msg = " inexistente";
            Console.WriteLine("Ruta Directa" + msg);
            ruta = GeneradorRuta.RutaDirecta(mapa, origen, destino);
            for (int i = 0; i < ruta.Count; i++)
                ruta[i].Marca = i % 9;
            mapaConsola.Imprimir(ruta);
            
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

        public static void ImprimirCaratula()
        {
            var consola = ConsolaCustom.Singleton();
            consola.Imprimir("\n\n\n\n\n");
            var builder = new StringBuilder();
            builder.AppendLine("             __    _____    _    _   _     _       __      _    _______   ___________   __");
            builder.AppendLine("            / /   |  ___|  | |  / / \\ \\   / /     |  \\    | |  |  _____| |____   ____|  \\ \\");
            builder.AppendLine("           / /    | |      | | / /   \\ \\_/ /      |   \\   | |  | |            | |        \\ \\");
            builder.AppendLine("          / /     | |___   | |/ /     \\   /       | |\\ \\  | |  | |_____       | |         \\ \\");
            builder.AppendLine("          \\ \\     |____ |  |   |       \\ /        | | \\ \\ | |  |  _____|      | |         / /");
            builder.AppendLine("           \\ \\        | |  | |\\ \\      | |        | |  \\ \\| |  | |            | |        / /");
            builder.AppendLine("            \\ \\    ___| |  | | \\ \\     | |    _   | |   \\   |  | |_____       | |       / /");
            builder.AppendLine("             \\_\\  |_____|  |_|  \\_\\    |_|   |_|  |_|    \\__|  |_______|      |_|      /_/");
            consola.Imprimir(builder.ToString(), ConsoleColor.Cyan);
            consola.Imprimir("\n\n                         Presione una tecla para comanzar la simulacion...\n\n\n", ConsoleColor.Blue);
            Console.ReadKey();
        }

    }
}