﻿using Backend.Estados;
using Backend.Localizaciones;
using Backend.Robots.TiposRobot;
using Backend.Transferibles;

namespace Backend.Robots.FabricaRobots
{
    public class FabricaK9 : FabricaRobot
    {
        public override Robot Crear(float velocidadMax, Localizacion2D localizacion, Cuartel cuartel)
        {
            return new K9(
                velocidadMax,
                localizacion,
                cuartel
            );
        }
    }
}
