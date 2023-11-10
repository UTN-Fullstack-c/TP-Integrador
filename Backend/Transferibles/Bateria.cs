using Backend.Exceptions;

namespace Backend.Transferibles
{
    public class Bateria
    {
        public int MiliAmperiosMax { get; }

        public int _miliAmperiosActuales;
        public int MiliAmperiorsActuales
        {
            get{ return _miliAmperiosActuales; }
        }

        public Bateria(int miliAmperiosMax)
        {
            this.MiliAmperiosMax = miliAmperiosMax;
            _miliAmperiosActuales = this.MiliAmperiosMax;
        }

        public int PorcentajeBateriaConsumida()
        {
            return 100 - PorcentajeBateriaActual();
        }

        public int PorcentajeBateriaActual()
        {
            float a = ((float)MiliAmperiorsActuales) / MiliAmperiosMax;
            a = a * 100;
            var b  = (int)a;
            return b;
        }

        public int BateriaConsumida()
        {
            return MiliAmperiosMax - MiliAmperiorsActuales;
        }

        public void RecargarBateriaCompleta()
        {
            _miliAmperiosActuales = MiliAmperiosMax;
        }

        public int RecargarBateria(int milliAmperios)
        { 
            _miliAmperiosActuales += milliAmperios;
            int excedente = 0;
            if(_miliAmperiosActuales > MiliAmperiosMax)
            {
                excedente = _miliAmperiosActuales - MiliAmperiosMax;
                _miliAmperiosActuales = MiliAmperiosMax;
            }
            return excedente;
        }

        public bool TieneSuficienteCarga(int miliAmperios)
        {
            return _miliAmperiosActuales >= miliAmperios;
        }

        public int ConsumirBateria(int miliAmperios)
        {
            if (!TieneSuficienteCarga(miliAmperios))
                throw new BateriaInsuficiente();
            _miliAmperiosActuales -= miliAmperios;
            return miliAmperios;
        }
    }
}