using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Pre_segundo_parcial.Modelo
{
    public class PedidoDAO
    {
        public static List<Pedido> getLista()
        {
            string sql = "select * from \"pedido\"";

            DataTable dt = Conexion.realizarConsulta(sql);

            List<Pedido> lista = new List<Pedido>();
            foreach (DataRow fila in dt.Rows)
            {
                Pedido p = new Pedido();
                p.pedido_id = Convert.ToInt32(fila[0].ToString());
                p.fecha_envio = DateTime.Parse(fila[1].ToString());
                p.usuario = fila[2].ToString();
                p.cantidad = Convert.ToInt32(fila[3].ToString());
                p.nombre = fila[4].ToString();
                lista.Add(p);
            }

            return lista;
        }
        
        public static List<Pedido> getListaUsuario(string usuario)
        {
            string sql = String.Format(
                "select * from pedido where usuario='{0}';",
                usuario);

            DataTable dt = Conexion.realizarConsulta(sql);

            List<Pedido> lista = new List<Pedido>();
            foreach (DataRow fila in dt.Rows)
            {
                Pedido p = new Pedido();
                p.pedido_id = Convert.ToInt32(fila[0].ToString());
                p.fecha_envio = DateTime.Parse(fila[1].ToString());
                p.usuario = fila[2].ToString();
                p.cantidad = Convert.ToInt32(fila[3].ToString());
                p.nombre = fila[4].ToString();
                lista.Add(p);
            }

            return lista;
        }

        public static void agregarPedido(Usuario u, Inventario I, DateTime fecha, int cantidad)
        {
            string sFecha = fecha.ToString("yyyy/MM/dd");

            string sql = String.Format(
                "insert into \"pedido\"" +
                "(\"fecha_envio\", \"usuario\", \"cantidad\", \"nombre\")" +
                "values ('{0}', '{1}', '{2}', '{3}');",
                sFecha, u.usuario, cantidad, I.nombre);

            Conexion.realizarAccion(sql);
        }
        
        public static List<Frecuencia> getEstadisticas()
        {
            string sql = "select usuario, count (*) as c from pedido group by usuario;";

            DataTable dt = Conexion.realizarConsulta(sql);

            List<Frecuencia> lista = new List<Frecuencia>();
            foreach (DataRow fila in dt.Rows)
            {
                Frecuencia f = new Frecuencia();
                f.usuario = fila[0].ToString();
                f.cantidad = Convert.ToInt32(fila[1].ToString());

                lista.Add(f);
            }
            return lista;
        }

        public static List<Frecuencia> getEstadisticasUsuario(string usuario)
        {
            string sql = String.Format(
                "select nombre, sum(cantidad) from pedido where usuario='{0}' group by nombre;",
                usuario);
            
            DataTable dt = Conexion.realizarConsulta(sql);

            List<Frecuencia> lista = new List<Frecuencia>();
            foreach (DataRow fila in dt.Rows)
            {
                Frecuencia f = new Frecuencia();
                f.usuario = fila[0].ToString();
                f.cantidad = Convert.ToInt32(fila[1].ToString());

                lista.Add(f);
            }
            return lista;
        }
    }
}
