using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class VentanaPrincipal : Form
    {
        public VentanaPrincipal()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que desea salir", "VentanaPrincipal", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
               == DialogResult.Yes)
            {
                Close();
            }
        }
        private void btnVentas_Click(object sender, EventArgs e)
        {
           
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCargos_Click(object sender, EventArgs e)
        {
            
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
          
        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
           
        }

        private void btnAlmacen_Click(object sender, EventArgs e)
        {
            

        }

        private void btnStock_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            VentanaEmpleado x;
            x = new VentanaEmpleado();
            x.ShowDialog();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            VentanaCargos x;
            x = new VentanaCargos();
            x.ShowDialog();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            VentanaProveedor x;
            x = new VentanaProveedor();
            x.ShowDialog();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            VentanaCliente x;
            x = new VentanaCliente();
            x.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            VentanaProductos x;
            x = new VentanaProductos();
            x.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            VentanaAlmacen x;
            x = new VentanaAlmacen();
            x.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            RegistroVenta x;
            x = new RegistroVenta();
            x.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void VentanaPrincipal_Load(object sender, EventArgs e)
        {
            //lblEmpleadoConectado.Text = mdlVariables.MiUsuarioConectado.NombresEmp;
            //if (mdlVariables.MiUsuarioConectado.Tipo == 'A')
            //{
            //    lblTipoEmpleado.Text = "ADMINISTRADOR";
            //}
            //else
            //{
                
            //    lblTipoEmpleado.Text = "EMPLEADO";
                //ventasPorFechaToolStripMenuItem.Visible = false;
                //consultarInventarioToolStripMenuItem.Visible = false;
            }
        }
    }
}
