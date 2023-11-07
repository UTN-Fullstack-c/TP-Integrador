using Backend;

namespace FrontEnd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fabrica = new FabricaRobot();
            UAV uav = fabrica.CreateUAV();
            M8 m8 = fabrica.CreateM8();
            Console.WriteLine(uav.Bateria);

            Console.WriteLine();
            Console.WriteLine(m8.Bateria);
        }
    }
}