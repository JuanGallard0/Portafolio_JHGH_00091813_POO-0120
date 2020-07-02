using System;
using System.Collections.Generic;
using System.Linq;

namespace Pre_tercer_parcial
{
    public class CImplementacion2 : IBridge
    {
        public void ConsultarHerramientas(List<HerramientasMinecraft> herramientas)
        {
            Console.Write("Tipo: ");
            string tipo = Console.ReadLine();

            foreach (HerramientasMinecraft h in herramientas)
            {
                if (h.tipo.Equals(tipo))
                    Console.WriteLine(h.ToString());
            }
        }

        public void BuscarMayorDaño(List<HerramientasMinecraft> herramientas)
        {
            Console.Write("Tipo: ");
            string tipo = Console.ReadLine();
            
            List<HerramientasMinecraft> tempList = new List<HerramientasMinecraft>();
            foreach (HerramientasMinecraft h in herramientas)
            {
                if (h.tipo.Equals(tipo))
                    tempList.Add(h);
            }
            
            HerramientasMinecraft mayorDaño = tempList.Aggregate((i1,i2) =>i1.daño > i2.daño ? i1 : i2);
            Console.WriteLine(mayorDaño.ToString());
            
            tempList.Clear();
        }
    }
}