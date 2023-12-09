using Backend.Localizaciones;
using FrontEnd.MapaNamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.MenuNamespace.MenuMapaNamespace
{
    public class CrearMapaPersonalizado : ICommand
    {
        public void Ejecutar()
        {
            var consola = ConsolaCustom.Singleton();
            var msgX = "Ingrese el largo del mapa : ";
            var msgY = "Ingrese el alto del mapa : ";
            var msgCuarteles = "Ingrese la maxima cantidad de cuarteles : ";
            var msgReciclaje = "Ingrese el maxima cantidad de puntos de reciclaje: ";
            var color = ConsoleColor.White;
            int xLength = consola.LeerEntero(1, null, msgX, color);
            int yLength = consola.LeerEntero(1, null, msgY, color);
            int cuarteles = consola.LeerEntero(1, null, msgCuarteles, color);
            int reciclaje = consola.LeerEntero(1, null, msgReciclaje, color);
            Mapa mapa = Mapa.Singleton(xLength, yLength, cuarteles, reciclaje);
            MapaConsola.Singleton().Mapa = mapa;
        }

        public override string ToString()
        {
            return "Crear nuevo mapa personalizado.";
        }
    }
}