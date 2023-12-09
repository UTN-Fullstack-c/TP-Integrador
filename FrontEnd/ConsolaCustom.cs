using FrontEnd.CustomException;
using System.Security.Cryptography;

namespace FrontEnd
{
    public class ConsolaCustom
    {
        private static ConsolaCustom? Consola;

        protected ConsolaCustom() { }

        public static ConsolaCustom Singleton()
        {
            if(Consola == null)
                Consola = new ConsolaCustom();
            return Consola;
        }
        public void Imprimir(string? mensaje, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.Write(mensaje);
        }

        public int LeerEntero(int? min, int? max, string mensaje, ConsoleColor color)
        {
            bool continuar = true;
            int entero = -1;
            while (continuar)
            {
                Imprimir(mensaje, color);
                Console.ForegroundColor = ConsoleColor.White;
                if (!int.TryParse(Console.ReadLine(), out entero))
                    InformarError("\nSe esperaba que ingrese un numero : ");
                else if (min != null && entero < min)
                    InformarError("\nSe esperaba un numero mayor a cero : ");
                else if (max != null && entero > max)
                    InformarError("\nEl numero ingresado es demasiado grande : ");
                else
                    continuar = false;
            }
            return entero;
        }

        private void InformarError(string mensaje)
        {
            Imprimir(mensaje, ConsoleColor.Red);
            bool continuar = LeerBooleano();
            if (!continuar)
                throw new UserAbortException("");
        }

        public bool LeerBooleano(string mensaje = "\nDesea volver a intentar?")
        {
            Imprimir(mensaje + " (S/N) : ", ConsoleColor.Yellow);
            string? respuesta = null;
            bool continuar = true;
            while (continuar)
            {
                respuesta = Console.ReadLine();
                if (respuesta != null)
                {
                    respuesta = respuesta.ToUpper();
                    if (respuesta.Equals("S") || respuesta.Equals("N"))
                        continuar = false;
                }
                if (continuar)
                    Imprimir("\nSe esperaba una letra S o N : ", ConsoleColor.Red);
            }
            return respuesta!.Equals("S");
        }
    }
}
