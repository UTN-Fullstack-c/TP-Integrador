using Backend.Transferibles;
using Backend.Localizaciones;
using Backend.Estados;
using System.Text;

namespace Backend.Robots
{
    public abstract class Robot : Localizable
    {
        protected static int ultimoIdRobot = 0;

        public const float FactorVelocidad = 0.5f;
        public Localizacion2D Localizacion { get; set; }
        public int Id { get; }
        public Bateria Bateria { get; }
        public Contenedor Contenedor { get; }
        public Estado Estado { get; set; }
        public float VelocidadMax { get; }
        private float danio;
        public float Danio { get { return danio; } set { danio = value; } }
        public Cuartel Cuartel { get; set; }


        protected Robot(
            float velocidadMax, 
            Contenedor baul, 
            Estado estado, 
            Bateria bateria,
            Localizacion2D localizacion,
            Cuartel cuartel
            )
        {
            VelocidadMax = velocidadMax;
            Estado = estado;
            Bateria = bateria;
            Bateria.CompletarCarga();
            Id = ++ultimoIdRobot;
            Localizacion = localizacion;
            Localizacion.Hospedar(this);
            danio = 0;
            Contenedor = baul;
            Cuartel = cuartel;
        }

        public bool Recorrer(List<Localizacion2D> ruta)
        {
            foreach(var localizacion in ruta)
            {
                if (!localizacion.Hospedar(this))
                    return false;
                Localizacion.Desalojar(this);
                this.Localizacion = localizacion;
            }
            return true;
        }

        public void DaniarComponentes(float probability, float porcentajeDanio)
        {
            float randomValue = (float)new Random().NextDouble();
            if (randomValue < probability)
            {
                danio += porcentajeDanio;
                if (danio > 1)
                    danio = 1;
            }
        }

        public void DaniarBateria(float porcentajeDanio)
        {
            Bateria.DisminuirCapacidadMaxima(porcentajeDanio);
        }

        public void Reparar()
        {
            Danio = 0;
        }

        public float GetVelocidadActual()
        {
            float porcentajeConsumido = 100 * Bateria.PorcentajeActual();
            float porcentajeVelocidadPerdida = porcentajeConsumido * FactorVelocidad;
            return VelocidadMax * (1+(porcentajeVelocidadPerdida / 100));
        }

        public void TransferirBateria(Robot robotDestino)
        {
            Bateria.Transferir(robotDestino.Bateria);
        }

        public void TransferirCargaFisica(Robot robotDestino)
        {
            Contenedor.Transferir(robotDestino.Contenedor);
        }

        public string GetNombre()
        {
            return GetType().Name + "-" + Id;
        }

        public override bool Equals(object? obj)
        {
            return obj is Robot && ((Robot)obj).Id == Id;
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public override string ToString()
        {
            return new StringBuilder()
                .Append("Nro. serie: ")
                .Append(Id)
                .Append("\nBateria: ")
                .Append(Bateria)
                .Append("\nDaño: ")
                .Append(Danio)
                .Append("%\n")
                .Append("Carga: ")
                .Append(Contenedor)
                .Append("\nVelocidad: ")
                .Append(GetVelocidadActual())
                .Append("Km/h\n")
                .Append("Localizacion: (")
                .Append(Localizacion.X)
                .Append(",")
                .Append(Localizacion.Y)
                .Append(")")
                .ToString();
        }

        public Localizacion2D GetLocalizacion()
        {
            return Localizacion;
        }
    }
}
