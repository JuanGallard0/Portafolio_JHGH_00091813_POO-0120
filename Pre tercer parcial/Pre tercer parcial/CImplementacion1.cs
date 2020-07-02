using System;
using System.Collections.Generic;
using System.Linq;

namespace Pre_tercer_parcial
{
    public class CImplementacion1 : IBridge
    {
        public void ConsultarHerramientas(List<HerramientasMinecraft> herramientas)
        {
            foreach (HerramientasMinecraft h in herramientas)
            {
                Console.WriteLine(h.ToString());
            }
        }

        public void BuscarMayorDaño(List<HerramientasMinecraft> herramientas)
        {
            HerramientasMinecraft mayorDaño = herramientas.Aggregate((i1,i2) => i1.daño > i2.daño ? i1 : i2);
            Console.WriteLine(mayorDaño.ToString());
        }
    }
}