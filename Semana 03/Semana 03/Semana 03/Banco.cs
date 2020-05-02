using System;

namespace Semana_03
{
    public static class Banco
    {
        public static void registrarTarjeta()
        {
            string numero = ConsolaJuegos.EmptyStringCheck("Numero de tarjeta: ");
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