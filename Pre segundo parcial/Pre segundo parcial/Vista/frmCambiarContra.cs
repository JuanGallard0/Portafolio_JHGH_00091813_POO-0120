using System;
using System.Windows.Forms;
using Pre_segundo_parcial.Modelo;
using Pre_segundo_parcial.Controlador;

namespace Pre_segundo_parcial.Vista
{
    public partial class frmCambiarContra : Form
    {
        public frmCambiarContra()
        {
            InitializeComponent();
        }

        private void frmCambiarContra_Load(object sender, EventArgs e)
        {
            // Actualizar ComboBox
            cmbUsuario.DataSource = null;
            cmbUsuario.ValueMember = "contrasena";
            cmbUsuario.DisplayMember = "usuario";
            cmbUsuario.DataSource = UsuarioDAO.getLista();
        }
        
        private void btnCambiarContra_Click_1(object sender, EventArgs e)
        {
            bool actualIgual = Encriptador.CompararMD5(txtActual.Text, cmbUsuario.SelectedValue.ToString());
            bool nuevaIgual = txtNueva.Text.Equals(txtRepetir.Text);
            bool nuevaValida = txtNueva.Text.Length > 0;

            if (actualIgual && nuevaIgual && nuevaValida)
            {
                try
                {
                    UsuarioDAO.actualizarContra(cmbUsuario.Text, Encriptador.CrearMD5(txtNueva.Text));

                    MessageBox.Show("¡Contraseña actualizada exitosamente!",
                        "JUMBO - Bottled coffee", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("¡Contraseña no actualizada! Favor intente mas tarde.",
                        "Error dialog", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("¡¡Favor verifique que los datos sean correctos!",
                    "Error dialog", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}