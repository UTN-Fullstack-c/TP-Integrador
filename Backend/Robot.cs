using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd
{
    public abstract class Robot
    {
        protected int id;
        protected float bateriaMax { get; }
        protected float cargaBateria;
        protected Estado Estado { get; set; }
        protected float pesoMax;
        protected List<Carga> cargas;
        protected float velocidadMax;
        protected float velocidadActual;
        protected string localizacion;
        protected float consumoBateria;
        public int Bateria { get; set; }
        public int Velocidad { get; set; } 

        public int Altura { get; set; }

        
        public void VelocidadACtual(float velocidadActual)
        {
            this.velocidadActual = velocidadActual;
        }

        public virtual void Moverse(float x, float y)
        {
            Console.WriteLine("");
        }

        public void TransferirBateria(Robot robot)
        {

        }

        public void TransferirCargaFisica(Robot robot)
        {

        }

        public void AsignarCarga(Carga carga)
        {

        }

        public void LLevarCargarAlCuartel()
        {

        }

        public void CargarBateriaEnCuartel()
        {

        }

        //public void SetEstado(Estado estado)
        //{
        //    this.estado = estado;
        //}

        protected Robot(int bateria, int velocidad)
        {
            Bateria = bateria;
            Velocidad = velocidad;
        }


    }

    
    
}
