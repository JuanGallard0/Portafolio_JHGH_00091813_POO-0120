using System;
using System.Collections.Generic;

namespace Pre_tercer_parcial
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<HerramientasMinecraft> herramientas = new List<HerramientasMinecraft>();
            CAbstraccion bridge;
            string tipo, material, encantamiento;
            int opcion = 0, daño, durabilidad;
            bool encantado;
            
            while (opcion != 6)
            {
                Console.WriteLine("1- Agregar herramienta \n" +
                                  "2- Consultar herramientas \n" +
                                  "3- Consultar herramientas por tipo \n" +
                                  "4- Buscar herramienta con daño mas alto \n" +
                                  "5- Buscar herramienta con daño mas alto por tipo \n" +
                                  "6- Salir");
                opcion = Convert.ToInt32(Console.ReadLine());
                
                switch (opcion)
                {
                    case 1:
                        Console.Write("Tipo: ");
                        tipo = Console.ReadLine();
                        Console.Write("Material: ");
                        material = Console.ReadLine();
                        Console.Write("Daño: ");
                        daño = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Durabilidad: ");
                        durabilidad = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Encanamiento (si/no): ");
                        encantamiento = Console.ReadLine();
                        if (encantamiento.Equals("si"))
                            encantado = true;
                        else
                            encantado = false;
                        
                        herramientas.Add(new HerramientasMinecraft(tipo, material, daño, durabilidad, encantado));
                        break;
                    case 2:
                        bridge = new CAbstraccion(1, herramientas);
                        bridge.ConsultarHerramientas(herramientas);
                        break;
                    case 3:
                        bridge = new CAbstraccion(2, herramientas);
                        bridge.ConsultarHerramientas(herramientas);
                        break;
                    case 4:
                        bridge = new CAbstraccion(1, herramientas);
                        bridge.BuscarMayorDaño(herramientas);
                        break;
                    case 5:
                        bridge = new CAbstraccion(2, herramientas);
                        bridge.BuscarMayorDaño(herramientas);
                        break;
                    case 6:
                        break;
                }
            }
        }
    }
}