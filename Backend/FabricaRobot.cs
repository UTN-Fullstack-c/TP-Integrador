namespace Backend
{
    public abstract class Robot
    {
        protected Robot(int bateria, int velocidad)
        {
            Bateria = bateria;
            Velocidad = velocidad;
        }

        public int Bateria { get; set; }
        public int Velocidad { get; set; }

    }

    public class UAV : Robot
    {
        public int Altitud { get; set; }

        public UAV(int bateria, int velocidad, int altitud) 
            : base(bateria, velocidad)
        {
            Altitud = altitud;
        }
    }

    public class M8 : Robot
    {
        public M8(int bateria, int velocidad) 
            : base(bateria, velocidad)
        {
        }
    }

    public class FabricaRobot
    {
        public UAV CreateUAV()
        {
            return new UAV(4000, 150, 3000);
        }
        public M8 CreateM8()
        {
            return new M8(2500, 80);
        }

    }
}