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
    public partial class RegistroVenta : Form
    {
        public RegistroVenta()
        {
            InitializeComponent();
        }

        private void RegistroVenta_Load(object sender, EventArgs e)
        {
            lblIGV.Enabled = false;
            txtIgv.Enabled = false;

            if (rbnGuia.Checked == true)
            {
                lblIGV.Enabled = true;
                txtIgv.Enabled = true;
            }
        }

        private void btnBusqueda_Click_1(object sender, EventArgs e)
        {
            VentanaCliente x;
            x = new VentanaCliente();
            x.ShowDialog();

            if (x.ClienteSeleccionado == null)
            {
                MessageBox.Show("La búsqueda fue cancelada");
            }
            else
            {
                txtDatos.Text = x.ClienteSeleccionado.NombresCli;
                txtDocIdentidad.Text = x.ClienteSeleccionado.DNICli;
            }

        }

        private void btnBusquedaProducto_Click_1(object sender, EventArgs e)
        {
            VentanaProductos x;
            x = new VentanaProductos();
            x.ShowDialog();

            if (x.ProductoSeleccionado == null)
            {
                MessageBox.Show("La búsqueda fue cancelada");
            }
            else
            {
                txtMarca.Text = x.ProductoSeleccionado.MarcaProd;
                txtDescripcion.Text = x.ProductoSeleccionado.NombreProd;
            }
        }
    }
}
