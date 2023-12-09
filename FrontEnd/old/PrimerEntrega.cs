using Backend.Exceptions;
using Backend.Localizaciones;
using Backend.Robots.TiposRobot;
using Backend.Robots;
using Backend.Transferibles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Robots.FabricaRobots;

namespace FrontEnd.old
{
    public class PrimerEntrega
    {
        static void Test(Localizacion2D[,] mapa)
        {/*
            Robot uav = FabricaRobot.Crear(0,100, new Localizacion2D(0, 0, "Terreno X"));
            Robot k9 = FabricaRobot.Crear(1, 50, new Localizacion2D(0, 0, "Terreno X"));
            Robot m8 = FabricaRobot.Crear(2, 25, new Localizacion2D(0, 0, "Terreno X"));
            CargaFisica carga;

            Console.WriteLine("\nPeso Maximo K9: " + k9.PesoMax);
            Console.WriteLine("Peso Maximo UAV: " + uav.PesoMax);
            Console.WriteLine("Peso Maximo M8: " + m8.PesoMax);

            carga = new CargaFisica(39);
            Console.WriteLine("\nNueva carga fisica: " + carga.Peso + "kg");
            Console.WriteLine("Asignando carga a K9...");
            k9.IntentarAsignarCargaFisica(carga);
            Console.WriteLine("Carga asignada a K9.");
            Console.WriteLine("Carga total K9: " + k9.PesoCargaTotal());

            carga = new CargaFisica(1);
            Console.WriteLine("\nNueva carga fisica: " + carga.Peso + "kg");
            Console.WriteLine("Asignando carga a K9...");
            k9.IntentarAsignarCargaFisica(carga);
            Console.WriteLine("Carga asignada a K9.");
            Console.WriteLine("Carga total K9: " + k9.PesoCargaTotal());

            try
            {
                carga = new CargaFisica(1);
                Console.WriteLine("\nNueva carga fisica: " + carga.Peso + "kg");
                Console.WriteLine("Asignando carga a K9...");
                k9.IntentarAsignarCargaFisica(carga);
                Console.WriteLine("Carga asignada a K9.");
                Console.WriteLine("Carga total K9: " + k9.PesoCargaTotal());
            }
            catch (PesoMaximoExcedido exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(exception.Message.ToString());
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            Console.WriteLine("Carga total K9: " + k9.PesoCargaTotal());
            Console.WriteLine("Velocidad de K9: " + k9.GetVelocidadActual());

            Console.WriteLine("\nBateria de K9: " + k9.Bateria.PorcentajeActual() + "%");
            var milliAmperiosInicial = k9.Bateria.Actual;
            Console.WriteLine("Bateria de K9: " + k9.Bateria.Actual + "mA");
            Console.WriteLine("Transfiriendo 1er carga de K9 hacia M8...");
            k9.TransferirCargaFisica(m8, 0);
            Console.WriteLine("Carga total K9: " + k9.PesoCargaTotal());
            Console.WriteLine("Carga total M8: " + m8.PesoCargaTotal());
            Console.WriteLine("Bateria actual de K9: " + k9.Bateria.PorcentajeActual() + "%");
            Console.WriteLine("MilliAmperios consumidos: " +
                (milliAmperiosInicial - k9.Bateria.Actual) + "mA"
            );
            Console.WriteLine("Velocidad de K9: " + k9.GetVelocidadActual());

            Console.WriteLine("\nBateria actual de UAV: " + uav.Bateria.Actual + "mA");
            Console.WriteLine("Transfiriendo bateria desde UAV hacia k9");
            uav.TransferirBateria(k9, uav.Bateria.Actual);
            Console.WriteLine("Bateria actual de K9: " + k9.Bateria.PorcentajeActual() + "%");
            Console.WriteLine("Bateria actual de UAV: " + uav.Bateria.Actual + "mA");
            /*
            Console.WriteLine("\nPosicion actual de m8: (" + m8.Localizacion.X + "," + m8.Localizacion.Y + ")");
            Console.WriteLine("Moviendo a m8, 2 unidades en X y 3 unidades en Y...");
            m8.Moverse(2, 3);
            Console.WriteLine("Posicion actual de m8: (" + m8.Localizacion.X + "," + m8.Localizacion.Y + ")");*/
        }
    }
}
