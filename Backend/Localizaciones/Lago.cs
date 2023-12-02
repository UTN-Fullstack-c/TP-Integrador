using Backend.Robots.TiposRobot;
using Backend.Robots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Localizaciones
{
    public class Lago : Localizacion2D
    {
        public Lago(int x, int y) : base(x, y, "Lago")
        {
        }

        public override bool Hospedar(Robot robot)
        {
            if (robot is K9 || robot is M8)
                return false;
            return base.Hospedar(robot);
        }
    }
}
