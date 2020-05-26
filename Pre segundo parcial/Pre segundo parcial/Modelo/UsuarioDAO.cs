using System;
using System.Collections.Generic;
using System.Data;
using Pre_segundo_parcial.Controlador;
using Pre_segundo_parcial.Modelo;

namespace ClaseGUI05.Modelo
{
    public static class UsuarioDAO
    {
        public static List<Usuario> getLista()
        {
            string sql = "select * from usuario";

            DataTable dt = Conexion.realizarConsulta(sql);

            List<Usuario> lista = new List<Usuario>();
            foreach (DataRow fila in dt.Rows)
            {
                Usuario u = new Usuario();
                u.usuario = fila[0].ToString();
                u.contrasena = fila[1].ToString();
                u.admin = Convert.ToBoolean(fila[2].ToString());
                u.nombre = fila[3].ToString();
                u.apellido = fila[4].ToString();
                u.calle = fila[5].ToString();
                u.ciudad = fila[6].ToString();
                u.cp = fila[7].ToString();
                u.telefono = fila[8].ToString();

                lista.Add(u);
            }
            return lista;
        }

        public static void actualizarContra(string usuario, string nuevaContra)
        {
            string sql = String.Format(
                "update usuario set contrasena='{0}' where usuario='{1}';",
                nuevaContra, usuario);
            
            Conexion.realizarAccion(sql);
        }

        public static void agregarUsuario(Usuario u)
        {
            u.contrasena = Encriptador.CrearMD5("0000");
            string sql = String.Format(
                "insert into \"usuario\"" + 
                "(\"usuario\", \"nombre\", \"apellido\", \"calle\", \"ciudad\",\"cp\", \"telefono\", \"contrasena\", \"admin\")" +
                "values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');",
                u.usuario, u.nombre, u.apellido, u.calle, u.ciudad, u.cp, u.telefono, u.contrasena, u.admin);
                
            Conexion.realizarAccion(sql);
        }
        
        public static void eliminar(string usuario)
        {
            string sql = String.Format(
                "delete from usuario where usuario='{0}';",
                usuario);
            
            Conexion.realizarAccion(sql);
        }
    }
}