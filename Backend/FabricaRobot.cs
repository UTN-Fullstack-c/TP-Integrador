using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd
{
    public class FabricaRobot
    {
        public Uav CreateUAV()
        {
            return new Uav(4000, 150, 3000);
        }
        public M8 CreateM8()
        {
            return new M8(2500, 80);
        }
    }
}
