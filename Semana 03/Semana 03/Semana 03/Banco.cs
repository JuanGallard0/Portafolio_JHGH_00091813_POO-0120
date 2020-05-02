using System;

namespace Semana_03
{
    public static class Banco
    {
        public static void registrarTarjeta()
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

            GestorArchivos.Anexar("Tarjetas.txt", numero);

            Console.WriteLine("Tarjeta creada exitosamente!");
        }

        public static void consultarTarjetas()
        {
            Console.WriteLine(GestorArchivos.Leer("Tarjetas.txt"));
        }

        public static bool realizarCompras(string tarjeta)
        {
            return GestorArchivos.Buscar("Tarjetas.txt", tarjeta);
        }
    }
}