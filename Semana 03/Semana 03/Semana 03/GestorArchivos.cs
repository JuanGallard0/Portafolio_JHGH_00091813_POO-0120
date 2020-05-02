using System;
using System.IO;

namespace Semana_03
{
    public static class GestorArchivos
    {
        public static string Leer(string pArchivo)
        {
            string read = null;
            try
            {
                read = File.ReadAllText(pArchivo);
            }
            catch (IOException e)
            {
                Console.WriteLine(e);
            }
            return read;
        }

        public static void Anexar(string pArchivo, string frase)
        {
            try
            {
                using (StreamWriter stream = File.AppendText(pArchivo))
                {
                    stream.WriteLine(frase);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e);
            }
        }

        public static bool Buscar(string pArchivo, string frase)
        {
            bool encontrado = false;
            try
            {
                using (StreamReader archivo = new StreamReader(pArchivo))
                {
                    string linea = "";
                    while (!encontrado && !archivo.EndOfStream)
                    {
                        linea = archivo.ReadLine();

                        if (linea.CompareTo(frase) == 0)
                            encontrado = true;
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e);
            }
            return encontrado;
        }
    }
}
