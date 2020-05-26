using System;
using System.Windows.Forms;
using ClaseGUI05.Modelo;
using Pre_segundo_parcial.Controlador;
using Pre_segundo_parcial.Modelo;

namespace Pre_segundo_parcial.Vista
{
    public partial class frmInicioSesion : Form
    {
        public frmInicioSesion()
        {
            InitializeComponent();
        }

        private void frmInicioSesion_Load(object sender, EventArgs e)
        {
            poblarControles();
        }

        private void poblarControles()
        {
            // Actualizar ComboBox
            cmbUsuario.DataSource = null;
            cmbUsuario.ValueMember = "contrasena";
            cmbUsuario.DisplayMember = "usuario";
            cmbUsuario.DataSource = UsuarioDAO.getLista();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            if (Encriptador.CompararMD5(txtContrasena.Text, cmbUsuario.SelectedValue.ToString()))
            {
                Usuario u = (Usuario) cmbUsuario.SelectedItem;
                
                MessageBox.Show("¡Bienvenido!", 
                    "JUMBO - Bottled coffee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                frmPrincipal ventana = new frmPrincipal(u);
                ventana.Owner = this;
                this.Hide();
                ventana.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("¡Contraseña incorrecta!", "Error dialog", 
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        
        private void txtContrasena_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnIniciarSesion_Click(sender, e);
        }

        private void btnCambiarContra_Click(object sender, EventArgs e)
        {
            frmCambiarContra unaVentana = new frmCambiarContra();
            unaVentana.ShowDialog();
            poblarControles();
        }
    }
}