namespace Pre_segundo_parcial.Modelo
{
    public class Usuario
    {
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public bool admin { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string calle { get; set; }
        public string ciudad { get; set; }
        public string cp { get; set; }
        public string telefono { get; set; }

        public Usuario(string usuario, string contrasena, bool admin, 
            string nombre, string apellido, string calle, string ciudad, 
            string cp, string telefono)
        {
            this.usuario = usuario;
            this.contrasena = contrasena;
            this.admin = admin;
            this.nombre = nombre;
            this.apellido = apellido;
            this.calle = calle;
            this.ciudad = ciudad;
            this.cp = cp;
            this.telefono = telefono;
        }

        public Usuario()
        {
        }
    }
}