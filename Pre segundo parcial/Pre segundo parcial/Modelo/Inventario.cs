using System;

namespace Pre_segundo_parcial.Modelo
{
    public class Inventario
    {
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int precio { get; set; }
        public int stock { set; get; }

        public Inventario(string nombre, string descripcion, int precio, int stock)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.precio = precio;
            this.stock = stock;
        }

        public Inventario()
        {
        }
    }
}