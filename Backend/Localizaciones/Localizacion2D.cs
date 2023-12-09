using Backend.Robots;
using Backend.Robots.TiposRobot;

namespace Backend.Localizaciones
{
    public class Localizacion2D
    {
        public virtual string NombreTerreno { get; set; }
        public virtual int? Marca { get; set; }
        public virtual int X { get; }
        public virtual int Y { get; }
        public List<Robot> RobotsEnZona { get; set; }

        public int probabildadAparicion { get; set; }

        protected Localizacion2D() { }
        public Localizacion2D(int x, int y, string nombre)
        {
            X = x;
            Y = y;
            NombreTerreno = nombre;
            RobotsEnZona = new List<Robot>();
        }

        public virtual bool Hospedar(Robot robot)
        {
            RobotsEnZona.Add(robot);
            return true;
        }

        public virtual bool Desalojar(Robot robot)
        {
            RobotsEnZona.Remove(robot);
            return true;
        }

        public override bool Equals(object? obj)
        {
            bool resultado = false;
            if(obj is Localizacion2D)
            {
                Localizacion2D casteo = (Localizacion2D)obj;
                resultado = casteo.X == X && casteo.Y == Y;
            }    
            return resultado;
        }
    }
}
