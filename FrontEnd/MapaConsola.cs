using Backend.Localizaciones;

namespace FrontEnd
{
    public class MapaConsola
    {
        public Mapa Mapa { get; }

        public MapaConsola(Mapa mapa)
        {
            Mapa = mapa;
        }

        void marcarZona(Localizacion2D zona, ConsoleColor color)
        {
            LocalizacionDestacada decorador = new LocalizacionDestacada(
                   zona,
                   color
               );
            Mapa.modificarZona(decorador);
        }

        public void Imprimir(
            List<Localizacion2D> recorrido,
            bool limpiarMapa = true,
            ConsoleColor color = ConsoleColor.Cyan
            )
        {
            if (recorrido.Count == 0)
                return;
            marcarZona(recorrido[0], ConsoleColor.White);
            for (int i = 1; i < recorrido.Count-1; i++)
                marcarZona(recorrido[i], color);
            marcarZona(recorrido[recorrido.Count-1], ConsoleColor.Gray);
            Imprimir(limpiarMapa);
        }

        public void Imprimir(bool clean = true)
        {
            if (clean)
                Console.Clear();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // Console.Write(" ");
            //for (int y = 0; y < mapa.GetLength(1); y++)
            //  Console.Write(y.ToString());
            string toPrint = " ";
            for (int y = Mapa.LargoVertical() - 1; y >= 0 ; y--)
            {
                // Console.Write((x<10)?"0":"" + x.ToString());
                for (int x = 0; x < Mapa.LargoHorizontal(); x++)
                {
                    bool noEscrito = true;
                    if (Mapa.Get(x, y) is LocalizacionDestacada)
                    {
                        LocalizacionDestacada localizacion = (LocalizacionDestacada)Mapa.Get(x, y);
                        Console.BackgroundColor = localizacion.Color;
                        toPrint = Mapa.Get(x, y).Marca % 9 + "";
                        Mapa.modificarZona(((LocalizacionDestacada)Mapa.Get(x, y)).Localizacion);
                    }
                    if (Mapa.Get(x, y) is Cuartel)
                        Console.BackgroundColor = ConsoleColor.Yellow;
                    else if (Mapa.Get(x, y) is Reciclaje)
                        Console.BackgroundColor = ConsoleColor.Black;
                    else if (Mapa.Get(x, y) is Lago)
                        Console.BackgroundColor = ConsoleColor.Blue;
                    else if (Mapa.Get(x, y) is Vertedero)
                        Console.BackgroundColor = ConsoleColor.Red;
                    else if (Mapa.Get(x, y) is VertederoElectronico)
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                    else if (Mapa.Get(x, y) is Localizacion2D)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        /*
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.Write(Mapa[x, y].NombreTerreno[0]);
                        noEscrito = false;
                        Console.BackgroundColor = ConsoleColor.Black;*/
                    }
                    if (noEscrito)
                        Console.Write((Mapa.Get(x,y).Robots.Count > 0 )? "*" : toPrint);
                    toPrint = " ";
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("");
            }
        }
    }
}
