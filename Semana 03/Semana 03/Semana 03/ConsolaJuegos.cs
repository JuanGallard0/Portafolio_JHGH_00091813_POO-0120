using System;
using Semana_03;

namespace Semana_03
{
    public static class ConsolaJuegos
    {
        public static void comprarJuego()
        {
            string numero = EmptyStringCheck("Numero de tarjeta: ");
            if (Banco.realizarCompras(numero))
            {
                string juego = EmptyStringCheck("Nombre del juego: ");
                GestorArchivos.Anexar("Juegos.txt", juego);
                Console.WriteLine("Juego comprado exitosamente!");
            }
        }

        public static void jugar()
        {
            string juego = EmptyStringCheck("Nombre del juego: ");
            if (GestorArchivos.Buscar("Juegos.txt", juego))
                Console.WriteLine("Listo para jugar!");
            else
                Console.WriteLine("Primero debe comprar el juego :(");
        }

        public static string EmptyStringCheck(string desc)
        {
            string str = null;
            bool loop = true;
            while (loop)
            {
                try
                {
                    loop = false;
                    Console.Write(desc);
                    str = Console.ReadLine();
                    if (String.IsNullOrEmpty(str))
                        throw new ArgumentNullException();
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine(e);
                    loop = true;
                }
            }
            return str;
        }
    }
}