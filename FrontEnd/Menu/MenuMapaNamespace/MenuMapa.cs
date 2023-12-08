using Backend.Localizaciones;
using FrontEnd.MapaNamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.MenuNamespace.MenuMapaNamespace
{
    public class MenuMapa : MenuConsola
    {
        public MenuMapa()
            : base("Selecciona mapa")
        {
            Commands.Add(new CrearMapaDefault());
            Commands.Add(new CrearMapaPersonalizado());
        }
    }
}