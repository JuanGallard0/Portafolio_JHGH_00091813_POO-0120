namespace Pre_tercer_parcial
{
    public class HerramientasMinecraft
    {
        public string tipo { get; set; }
        public string material { get; set; }
        public int daño { get; set; }
        public int durabilidad { get; set; }
        public bool encantamiento { get; set; }

        public HerramientasMinecraft(string tipo, string material, int daño, int durabilidad, bool encantamiento)
        {
            this.tipo = tipo;
            this.material = material;
            this.daño = daño;
            this.durabilidad = durabilidad;
            this.encantamiento = encantamiento;
        }

        public override string ToString()
        {
            return string.Format("Tipo: {0}, Material: {1}, Daño: {2}, Durabilidad: {3}, " +
                                 "Encantamiento: {4}", tipo, material, daño, durabilidad, encantamiento);
        }
    }
}