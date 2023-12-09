using Backend.Robots;

namespace Backend.Localizaciones
{
    public class Cuartel : Localizacion2D, PuntoDeCarga, Localizable
    {
        public List<Robot> RobotsActivos { get; set; }
        public List<Robot> Reserva { get; set; }
        public int NumeroCuartel { get; set; }
        public List<Action<String>> Suscriptors { get; set; }


        public Cuartel(int x, int y, int numeroCuartel) 
            : base(x, y, "Cuartel " + numeroCuartel)
        {
            Reserva = new List<Robot>();
            RobotsActivos = new List<Robot>();
            Suscriptors = new List<Action<String>>();
            NumeroCuartel = numeroCuartel;
        }

 
        
        // ARREGLAR LOS RETURNS 


        public bool OciososLLevarReciclados()
        {
            foreach (var robot in RobotsActivos)
            {
                List<Localizacion2D> mejorRuta = null;
                Vertedero vertederoMasCercano = MasCercano(robot, Mapa.Singleton().Vertederos);
                if (vertederoMasCercano == null)
                    return false;
                Reciclaje reciclajeMasCercano = MasCercano(robot, Mapa.Singleton().Reciclajes);
                if (reciclajeMasCercano == null)
                    return false;
                if (Enviar(robot, vertederoMasCercano))
                {
                    robot.Contenedor.CompletarCarga();
                    Notificar("Robot en vertedero");
                    if (Enviar(robot, reciclajeMasCercano))
                    {
                        robot.Contenedor.DescargaCompleta();
                        return true;
                    }
                }
                return false;
            }
            return true;
        }

        public bool RepararTodos()
        {
            bool todosReparados = true;
            foreach (var robot in RobotsActivos)
            {
                if (robot.Danio > 0)
                {
                    bool pudoLlegar = Enviar(robot, this);
                    if (pudoLlegar)
                        Reparar(robot);
                    todosReparados = todosReparados && pudoLlegar;
                }
            }
            return todosReparados;
        }

        public void Notificar(String message)
        {
            foreach (var suscriptor in Suscriptors)
                suscriptor(message);
        }

        public Zona MasCercano<Zona>(Robot robot, List<Zona> destinos)
            where Zona : Localizacion2D
        {
            List<Localizacion2D> mejorRuta = null;
            Zona masCercano = null;
            foreach (var zona in destinos)
            {
                List<Localizacion2D> ruta = GeneradorRuta.RutaDirecta(
                    Mapa.Singleton(),
                    robot.Localizacion,
                    zona
                );
                if(ruta.Count>0)
                    if (mejorRuta == null || mejorRuta.Count > ruta.Count)
                    {
                        mejorRuta = ruta;
                        masCercano = zona;
                    }
            }
            return masCercano;
        }

        public void Recall()
        {
            foreach (var robot in RobotsActivos)
                Recall(robot);
        }

        public void Recall(Robot robot)
        {
            Enviar(robot, this);
        }

        public bool Enviar(Robot robot, Localizacion2D destino)
        {
            Localizacion2D origen = robot.Localizacion;
            List<Localizacion2D> ruta = GeneradorRuta.RutaDirecta(
                Mapa.Singleton(), 
                robot.Localizacion, 
                destino
            );
            if (!robot.Recorrer(ruta))
            {
                origen.Hospedar(robot);
                return false;
            }
            return true;
        }

        public void CargarBateria(Robot robot)
        {
            robot.Bateria.CompletarCarga();
        }

        public void RecibirCargamento(Robot robot)
        {
            robot.Contenedor.DescargaCompleta();
        }

        public bool AgregarRobot(Robot robot)
        {
            bool ok = false;
            if (!RobotsActivos.Contains(robot) && !Reserva.Contains(robot))
            { 
                RobotsActivos.Add(robot);
                ok = true;
            }
            return ok;
        }

        public bool AgregarReserva(Robot robot)
        {
            bool ok = false;
            if (!Reserva.Contains(robot))
            {
                int i = -1;
                while (++i < RobotsActivos.Count && RobotsActivos[i].Id != robot.Id) ;
                if (i < RobotsActivos.Count)
                    RobotsActivos.RemoveAt(i);
                Reserva.Add(robot);
                ok = true;
            }
            return ok;
        }

        public bool RemoverReserva(Robot robot)
        {
            bool ok = false;
            int i = -1;
            while (++i < Reserva.Count && Reserva[i].Id != robot.Id) ;
            if (i < Reserva.Count)
            {
                Reserva.RemoveAt(i);
                RobotsActivos.Add(robot);
                ok = true;
            }
            return ok;
        }

        public void Reparar(Robot robot)
        {
            robot.Bateria.CompletarCarga();
        }

        public void RepararRobot(Robot robot)
        {
            robot.Reparar();
        }

        public Localizacion2D GetLocalizacion()
        {
            return this;
        }
    }
}
