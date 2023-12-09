namespace Backend.Transferibles
{
    public class Transferible
    {
        protected int _max;
        public int Max { get { return _max; } }

        protected int _actual;
        public int Actual { get { return _actual; } }
        protected string Unidad;

        public Transferible(int max, string unidad)
        {
            _max = max;
            _actual = 0;
            Unidad = unidad;
        }
        
        public int PorcentajeActual()
        {
            float a = ((float)Actual) / Max;
            a = a * 100;
            var b  = (int)a;
            return b;
        }

        public void Transferir(Transferible fuente)
        {
            int total = Actual + fuente.Actual;
            int excedente = total - Max;
            if (excedente > 0)
                _actual = Max;
            else
                excedente = 0;
            fuente._actual = excedente;
        }

        public void CompletarCarga()
        {
            _actual = Max;
        }

        public void DescargaCompleta()
        {
            _actual = 0;
        }

        public override string ToString()
        {
            return PorcentajeActual() + "%" + " | " + _actual + Unidad + "/" + Max + Unidad; ;
        }

        public void DisminuirCapacidadMaxima(float procentajeDisminucion)
        {
            float factor = (1 - procentajeDisminucion);
            float nuevoMaximo = Max * factor;
            _max = (int)nuevoMaximo;
            if(_actual > Max)
                _actual = Max;
        }
    }
}