using Backend.Transferibles;
using Backend.Exceptions;
using Backend.Localizaciones;
using Backend.Estados;
using System.Text;

namespace Backend.Robots
{
    public abstract class Robot
    {
        public const float FactorVelocidad = 0.5f;

        private List<CargaFisica> _cargas;
        public Localizacion2D Localizacion { get; set; }
        public int IdCuartel { get; }
        public Bateria Bateria { get; }
        public Estado Estado { get; set; }
        public float PesoMax { get; }
        public float Carga { get; set; }
        public float VelocidadMax { get; }
        private float danio;
        public float Danio { get { return danio; } set { danio = value; } }

        public override string ToString()
        {
            return new StringBuilder()
                .Append("Bateria: ")
                .Append(Bateria.PorcentajeBateriaConsumida())
                .Append("mA\n")
                .Append("Daño: ")
                .Append(Danio)
                .Append("%\n")
                .Append("Carga: ")
                .Append(Carga)
                .Append("Kg\n")
                .Append("Velocidad: ")
                .Append(GetVelocidadActual())
                .Append("Km/h")
                .ToString();
        }

        protected Robot(
            float velocidadMax, 
            float pesoMax, 
            Estado estado, 
            Bateria bateria, 
            int id, 
            Localizacion2D localizacion
            )
        {
            VelocidadMax = velocidadMax;
            PesoMax = pesoMax;
            Estado = estado;
            Bateria = bateria;
            IdCuartel = id;
            Localizacion = localizacion;
            Localizacion.Hospedar(this);
            _cargas = new List<CargaFisica>();
            danio = 0;
            Carga = 0;
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
            float factorDanio = (1 - porcentajeDanio);
            float nuevoMaximo = Bateria.MiliAmperiosMax * factorDanio;
            Bateria.MiliAmperiosMax = (int) nuevoMaximo;
        }

        public void Reparar()
        {
            Danio = 0;
        }

        public float GetVelocidadActual()
        {
            float porcentajeVelocidadPerdida =
                Bateria.PorcentajeBateriaConsumida() * FactorVelocidad;
            return VelocidadMax * (1+(porcentajeVelocidadPerdida / 100));
        }

        // Retorna los milliAmperios que realmente se transfirio.
        // Lanza excepcion si no hay suficiente para transferir.
        public int TransferirCargaBateria(Robot robot, int milliAmperios)
        {
            if (Bateria.MiliAmperiorsActuales < milliAmperios)
                throw new BateriaInsuficiente();
            if (robot.Bateria.BateriaConsumida() < milliAmperios)
                milliAmperios = robot.Bateria.BateriaConsumida();
            Bateria.ConsumirBateria(milliAmperios);
            robot.Bateria.RecargarBateria(milliAmperios);
            return milliAmperios;
        }

        public void TransferirCargaFisica(Robot robotDestino, uint iesimaCarga)
        {
            if (iesimaCarga >= _cargas.Count )
                throw new IndiceInvalido("Se intente quitar una carga que no existe");
            CargaFisica carga = _cargas[(int)iesimaCarga];
            robotDestino.IntentarAsignarCargaFisica(carga);
            _cargas.Remove(carga);
            Bateria.ConsumirBateria(1300);
        }

        public float PesoCargaTotal()
        {
            float total = 0;
            foreach (CargaFisica carga in _cargas)
                total += carga.Peso;
            return total;
        }

        public void IntentarAsignarCargaFisica(CargaFisica carga)
        {
            if (PesoCargaTotal() + carga.Peso > PesoMax)
                throw new PesoMaximoExcedido();
            _cargas.Add(carga);
        }

        public void LLevarCargarAlCuartel()
        {

        }

        public void CargarBateriaEnCuartel()
        {

        }
    }
}
