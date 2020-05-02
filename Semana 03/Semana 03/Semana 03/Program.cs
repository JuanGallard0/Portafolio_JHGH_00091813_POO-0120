using System;

namespace Semana_03
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            bool continuar = true;
            int opcion = 0;
            do{
                try
                {
                    Console.Write(menu());
                    opcion = Convert.ToInt32(Console.ReadLine());
                    if (opcion < 1 || opcion > 5)
                        throw new ArgumentOutOfRangeException();
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e);
                }
                switch(opcion){
                    case 1: Banco.registrarTarjeta(); break;
                    case 2: Banco.consultarTarjetas(); break;
                    case 3: ConsolaJuegos.comprarJuego(); break;
                    case 4: ConsolaJuegos.jugar(); break;
                    case 5: continuar = false; break;
                    default: Console.WriteLine("Opcion errónea!"); break;
                }
            }while(continuar);
            Console.WriteLine("\nTenga un buen día!");
        }
        
        static string menu(){
            return "\nBienvenido:\n" +
                   "1) Registrar tarjeta (banco).\n" +
                   "2) Consultar tarjetas (banco).\n" +
                   "3) Comprar videojuego (consola).\n" +
                   "4) Jugar videojuego (consola).\n" +
                   "5) Salir.\n" +
                   "Opción elegida: ";
        }
    }
}