using Backend.Localizaciones;
using FrontEnd.MapaNamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.MenuNamespace.MenuMapaNamespace
{
    public class CrearMapaDefault : ICommand
    {
        private const int Y_MAP_LENGTH = 30;
        private const int X_MAP_LENGTH = 100;
        private const int MAX_CUARTELES = 3;
        private const int MAX_RECICLAJE = 5;

        public void Ejecutar()
        {
            Mapa mapa = new Mapa(
                X_MAP_LENGTH,
                Y_MAP_LENGTH,
                MAX_CUARTELES,
                MAX_RECICLAJE
            );
            MapaConsola.Singleton().Mapa = mapa;
        }

        public override string ToString()
        {
            return "Crear mapa por defecto.";
        }
    }
}