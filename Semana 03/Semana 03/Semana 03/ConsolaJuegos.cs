using System;
using Semana_03;

namespace Semana_03
{
    public static class ConsolaJuegos
    {
        public static void comprarJuego()
        {
            string numero = null;
            bool loop = true;
            while (loop)
            {
                try
                {
                    loop = false;
                    Console.Write("Numero de tarjeta: ");
                    numero = Console.ReadLine();
                    if (String.IsNullOrEmpty(numero))
                        throw new ArgumentNullException();
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine(e);
                    loop = true;
                }
            }
            if (Banco.realizarCompras(numero))
            {
                string juego = null;
                loop = true;
                while (loop)
                {
                    try
                    {
                        loop = false;
                        Console.Write("Nombre del juego: ");
                        juego = Console.ReadLine();
                        if (String.IsNullOrEmpty(juego))
                            throw new ArgumentNullException();
                    }
                    catch (ArgumentNullException e)
                    {
                        Console.WriteLine(e);
                        loop = true;
                    }
                }
                GestorArchivos.Anexar("Juegos.txt", juego);
                Console.WriteLine("Juego comprado exitosamente!");
            }
        }

        public static void jugar()
        {
            string juego = null;
            bool loop = true;
            while (loop)
            {
                try
                {
                    loop = false;
                    Console.Write("Nombre del juego: ");
                    juego = Console.ReadLine();
                    if (String.IsNullOrEmpty(juego))
                        throw new ArgumentNullException();
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine(e);
                    loop = true;
                }
            }
            if (GestorArchivos.Buscar("Juegos.txt", juego))
                Console.WriteLine("Listo para jugar!");
            else
                Console.WriteLine("Primero debe comprar el juego :(");
        }
    }
}