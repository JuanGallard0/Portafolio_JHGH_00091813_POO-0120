using System.Collections.Generic;

namespace Pre_tercer_parcial
{
    public class CAbstraccion : IBridge
    {
        private IBridge implementacion;
        private List<HerramientasMinecraft> herramientas;

        public CAbstraccion(IBridge implementacion, List<HerramientasMinecraft> herramientas)
        {
            this.implementacion = implementacion;
            this.herramientas = herramientas;
        }
        
        public CAbstraccion(int tipo, List<HerramientasMinecraft> herramientas)
        {
            if (tipo == 1)
                implementacion = new CImplementacion1();
            if (tipo == 2)
                implementacion = new CImplementacion2();

            this.herramientas = herramientas;
        }

        public void ConsultarHerramientas(List<HerramientasMinecraft> herramientas)
        {
            implementacion.ConsultarHerramientas(herramientas);
        }

        public void BuscarMayorDaño(List<HerramientasMinecraft> herramientas)
        {
            implementacion.BuscarMayorDaño(herramientas);
        }
    }
}