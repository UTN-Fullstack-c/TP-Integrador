using Backend.Robots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Localizaciones
{
    public class VertederoElectronico : Localizacion2D
    {
        private const float PORCENTAJE_DANIO = 0.2f;

        public VertederoElectronico(int x, int y) : base(x, y, "Vertedero Electronico")
        {
        }

        public override bool Hospedar(Robot robot)
        {
            robot.DaniarBateria(PORCENTAJE_DANIO);
            return base.Hospedar(robot);
        }
    }

}
