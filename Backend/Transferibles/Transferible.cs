namespace Backend.Transferibles
{
    public class Transferible
    {
        public int Max { get; set; }

        private int _actual;
        public int Actual { get { return _actual; } }

        public Transferible(int max)
        {
            Max = max;
            _actual = Max;
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
    }
}