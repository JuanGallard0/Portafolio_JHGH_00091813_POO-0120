using System.Collections.Generic;

namespace Pre_tercer_parcial
{
    public interface IBridge
    {
        void ConsultarHerramientas(List<HerramientasMinecraft> herramientas);
        void BuscarMayorDaño(List<HerramientasMinecraft> herramientas);
    }
}