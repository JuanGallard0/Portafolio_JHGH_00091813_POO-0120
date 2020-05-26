using System;
using System.Collections.Generic;
using System.Data;

namespace Pre_segundo_parcial.Modelo
{
    public class InventarioDAO
    {
        public static List<Inventario> getLista()
                {
                    string sql = "select * from \"inventario\" order by \"stock\" desc";
        
                    DataTable dt = Conexion.realizarConsulta(sql);
                    
                    List<Inventario> lista = new List<Inventario>();
                    foreach (DataRow fila in dt.Rows)
                    {
                        Inventario I = new Inventario();
                        I.nombre = fila[0].ToString();
                        I.descripcion = fila[1].ToString();
                        I.precio = Convert.ToInt32(fila[2].ToString());
                        I.stock = Convert.ToInt32(fila[3].ToString());
                        lista.Add(I);
                    }
                    return lista;
                }

        public static void agregarArticulo(Inventario I)
        {
            string sql = String.Format(
                "insert into \"inventario\"" + 
                "(\"nombre\", \"descripcion\", \"precio\", \"stock\")" +
                "values ('{0}', '{1}', '{2}', '{3}');",
                I.nombre, I.descripcion, I.precio, I.stock);
                
            Conexion.realizarAccion(sql);
        }
        
        public static void eliminarArticulo(string nombre)
        {
            string sql = String.Format(
                "delete from inventario where nombre='{0}';",
                nombre);
            
            Conexion.realizarAccion(sql);
        }
        
        public static void actualizarStock(string nombre, int nuevoStock)
        {
            string sql = String.Format(
                "update inventario set stock='{0}' where nombre='{1}';",
                nuevoStock, nombre);
            
            Conexion.realizarAccion(sql);
        }
    }
}