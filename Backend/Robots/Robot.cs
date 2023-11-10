using Backend.Transferibles;
using Backend.Exceptions;
using Backend.Localizaciones;
using Backend.Estados;

namespace Backend.Robots
{
    public abstract class Robot
    {
        public const float FactorVelocidad = 0.5f;

        private List<CargaFisica> _cargas;
        
        private Localizacion2D _localizacion;
        public Localizacion2D Localizacion { 
            get { return _localizacion; } 
        }

        public int IdCuartel { get; }
        public Bateria Bateria { get; }
        public Estado Estado { get; set; }
        public float PesoMax { get; }
        public float VelocidadMax { get; }

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
            _localizacion = localizacion;
            _cargas = new List<CargaFisica>();
        }

        public float GetVelocidadActual()
        {
            float porcentajeVelocidadPerdida =
                Bateria.PorcentajeBateriaConsumida() * FactorVelocidad;
            return VelocidadMax * (1+(porcentajeVelocidadPerdida / 100));
        }

        public virtual void Moverse(int x, int y)
        {
            _localizacion.X += x;
            _localizacion.Y += y;
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
