using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ClaseGUI05.Modelo;
using Pre_segundo_parcial.Modelo;
using LiveCharts;
using LiveCharts.Wpf;
using CartesianChart = LiveCharts.WinForms.CartesianChart;

namespace Pre_segundo_parcial.Vista
{
    public partial class frmPrincipal : Form
    {
        private Usuario usuario;
        private CartesianChart graficoAdmin;
        private CartesianChart graficoCommon;
        public frmPrincipal(Usuario pUsuario)
        {
            InitializeComponent();
            usuario = pUsuario;
            DoubleBuffered = true;
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            lblBienvenida.Text =
                "Bienvenido " + usuario.usuario + " [" + (usuario.admin ? "Administrador" : "Usuario") + "]";

            graficoCommon = new CartesianChart();
            this.Controls.Add(graficoCommon);
            graficoCommon.Parent = tabContenedor.TabPages[5];
            configurarGraficoCommon();
            
            actualizarControlesCommon();
            actualizarTablaCommon();
            
            if (usuario.admin)
            {
                graficoAdmin = new CartesianChart();
                this.Controls.Add(graficoAdmin);
                graficoAdmin.Parent = tabContenedor.TabPages[3];
             
                configurarGraficoAdmin();
                actualizarControles();
                actualizarTablas();
            }
            else
            {
                tabContenedor.TabPages[0].Parent = null;
                tabContenedor.TabPages[0].Parent = null;
                tabContenedor.TabPages[0].Parent = null;
                tabContenedor.TabPages[0].Parent = null;
            }
        }
        
        private void configurarGraficoAdmin()
        {
            graficoAdmin.Top = 10;
            graficoAdmin.Left = 10;
            graficoAdmin.Width = graficoAdmin.Parent.Width - 20;
            graficoAdmin.Height = graficoAdmin.Parent.Height - 20;

            graficoAdmin.Series = new SeriesCollection
            {
                new ColumnSeries{Title = "Pedidos por usuarios.", Values = new ChartValues<int>(), DataLabels = true}
            };

            graficoAdmin.AxisX.Add(new Axis{Labels = new List<string>()});
            graficoAdmin.AxisX[0].Separator = new Separator() {Step = 1, IsEnabled = false};
            graficoAdmin.LegendLocation = LegendLocation.Top;
        }
        
        private void configurarGraficoCommon()
        {
            graficoCommon.Top = 10;
            graficoCommon.Left = 10;
            graficoCommon.Width = graficoCommon.Parent.Width - 20;
            graficoCommon.Height = graficoCommon.Parent.Height - 20;

            graficoCommon.Series = new SeriesCollection
            {
                new ColumnSeries{Title = "Artículos pedidos.", Values = new ChartValues<int>(), DataLabels = true}
            };

            graficoCommon.AxisX.Add(new Axis{Labels = new List<string>()});
            graficoCommon.AxisX[0].Separator = new Separator() {Step = 1, IsEnabled = false};
            graficoCommon.LegendLocation = LegendLocation.Top;
        }
        
        private void poblarGraficoAdmin()
        {
            graficoAdmin.Series[0].Values.Clear();
            graficoAdmin.AxisX[0].Labels.Clear();
          
            foreach (Frecuencia f in PedidoDAO.getEstadisticas())
            {
                graficoAdmin.Series[0].Values.Add(f.cantidad);
                graficoAdmin.AxisX[0].Labels.Add(f.usuario);
            }
        }
        
        private void poblarGraficoCommon()
        {
            try
            {
                graficoCommon.Series[0].Values.Clear();
                graficoCommon.AxisX[0].Labels.Clear();

                foreach (Frecuencia f in PedidoDAO.getEstadisticasUsuario(usuario.usuario))
                {
                    graficoCommon.Series[0].Values.Add(f.cantidad);
                    graficoCommon.AxisX[0].Labels.Add(f.usuario);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error: " + exception.Message, "Error dialog",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void actualizarControles()
        {
            // Realizar consulta a la base de datos
            List<Usuario> listaU = UsuarioDAO.getLista();

            comboBox1.DataSource = null;
            comboBox1.DisplayMember = "usuario";
            comboBox1.DataSource = listaU;

            List<Inventario> listaI = InventarioDAO.getLista();

            comboBox2.DataSource = null;
            comboBox2.DisplayMember = "nombre";
            comboBox2.DataSource = listaI;

            comboBox3.DataSource = null;
            comboBox3.DisplayMember = "nombre";
            comboBox3.DataSource = listaI;

            actualizarControlesCommon();

            poblarGraficoAdmin();
        }

        private void actualizarControlesCommon()
        {
            // Realizar consulta a la base de datos
            List<Inventario> listaI = InventarioDAO.getLista();

            comboBox4.DataSource = null;
            comboBox4.DisplayMember = "nombre";
            comboBox4.DataSource = listaI;

            poblarGraficoCommon();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmInicioSesion ventana = new frmInicioSesion();
            ventana.Owner = this;
            this.Hide();
            ventana.ShowDialog();
            this.Close();
        }

        private void btnLimpiarUsuario_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            // Crear un cliente y llenar sus datos desde la vista
            Usuario u = new Usuario();
            u.usuario = textBox1.Text;
            u.nombre = textBox2.Text;
            u.apellido = textBox3.Text;
            u.calle = textBox4.Text;
            u.ciudad = textBox5.Text;
            u.cp = textBox6.Text;
            u.telefono = textBox7.Text;
            u.admin = checkBox1.Checked;
            try
            {
                // Enviar a modelo, el se encargara de almacenarlo en la BDD
                UsuarioDAO.agregarUsuario(u);

                MessageBox.Show("Usuario agregado exitosamente (contraseña provisional: 0000)", "JUMBO - Bottled coffee",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar la vista, los eventos se pueden invocar desde codigo
                btnLimpiarUsuario_Click(sender, e);

                // Actualizar la vista, los ComboBox de la primer pestana
                actualizarControles();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error: " + exception.Message, "Error dialog",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioDAO.eliminar(comboBox1.Text);
                MessageBox.Show("Usuario eliminado exitosamente", "JUMBO - Bottled coffee",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                actualizarControles();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error: " + exception.Message, "Error dialog",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            try
            {
                Inventario I = new Inventario();
                I.nombre = textBox8.Text;
                I.descripcion = textBox9.Text;
                I.precio = Convert.ToInt32(textBox10.Text);
                I.stock = Convert.ToInt32(numericUpDown1.Text);

                // Enviar a modelo, el se encargara de almacenarlo en la BDD
                InventarioDAO.agregarArticulo(I);

                MessageBox.Show("Articulo agregado exitosamente", "JUMBO - Bottled coffee",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar la vista, los eventos se pueden invocar desde codigo
                btnLimpiarArticulo_Click(sender, e);

                // Actualizar la vista, los ComboBox de la primer pestana
                actualizarControles();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error: " + exception.Message, "Error dialog",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiarArticulo_Click(object sender, EventArgs e)
        {
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            numericUpDown1.Value = 0;
        }

        private void btnEliminarArticulo_Click(object sender, EventArgs e)
        {
            try
            {
                InventarioDAO.eliminarArticulo(comboBox2.Text);
                MessageBox.Show("Articulo eliminado exitosamente", "JUMBO - Bottled coffee",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                actualizarControles();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error: " + exception.Message, "Error dialog",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificarArticulo_Click(object sender, EventArgs e)
        {
            try
            {
                InventarioDAO.actualizarStock(comboBox3.Text, Convert.ToInt32(numericUpDown2.Text));
                MessageBox.Show("Stock acctualizado exitosamente", "JUMBO - Bottled coffee",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                actualizarControles();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error" + exception.Message, "Error dialog",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarPedido_Click(object sender, EventArgs e)
        {
            try
            {
                Inventario I = (Inventario) comboBox4.SelectedItem;
                
                PedidoDAO.agregarPedido(usuario, I, dateTimePicker1.Value, Convert.ToInt32(numericUpDown3.Text));
                
                MessageBox.Show("Pedido agregado exitosamente", "JUMBO - Bottled coffee",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (usuario.admin)
                {
                    actualizarTablas();
                    actualizarControles();
                }
                else
                {
                    actualizarTablaCommon();
                    actualizarControlesCommon();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error: " + exception.Message, "Error dialog",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void actualizarTablas()
        {
            actualizarTablaCommon();
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = PedidoDAO.getLista();
        }
        
        private void actualizarTablaCommon()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = PedidoDAO.getListaUsuario(usuario.usuario);
        }
    }
}