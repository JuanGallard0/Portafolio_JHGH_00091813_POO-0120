using System;

namespace Pre_segundo_parcial.Modelo
{
    public class Pedido
    {
        public int pedido_id { get; set; }
        public DateTime fecha_envio { set; get; }
        public string usuario { set; get; }
        public int cantidad { set; get; }
        public string nombre { set; get; }


        public Pedido(int pedidoId, DateTime fechaEnvio, string usuario, int cantidad, string nombre)
        {
            pedido_id = pedidoId;
            fecha_envio = fechaEnvio;
            this.usuario = usuario;
            this.cantidad = cantidad;
            this.nombre = nombre;
        }

        public Pedido()
        {
        }
    }
}