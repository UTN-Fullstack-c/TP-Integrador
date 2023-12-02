using Backend.Robots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Localizaciones
{
    public class Vertedero : Localizacion2D
    {
        private const float PROBABILIDAD_DANIO = 0.05f;

        public Vertedero(int x, int y) : base(x, y, "Vertedero")
        {
        }

        public override bool Hospedar(Robot robot)
        {
            float porcentageDanio = (float)new Random().NextDouble();
            robot.DaniarComponentes(PROBABILIDAD_DANIO, porcentageDanio);
            return base.Hospedar(robot);
        }
    }
}
