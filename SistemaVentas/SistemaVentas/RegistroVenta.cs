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

 
        private int _IdProd;

        public int IdProd
        {
            get { return _IdProd; }
            set { _IdProd = value; }
        }

        private void RegistroVenta_Load(object sender, EventArgs e)
        {
            lblIGV.Visible = false;
            txtIgv.Visible = false;

            if (rbnGuia.Checked == true)
            {
                lblIGV.Visible = true;
                txtIgv.Visible = true;
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
                IdProd = x.ProductoSeleccionado.IdProducto;

                cmbMedida.Items.Clear();
                foreach (clsPrecio ELEMENTO in clsPrecio.ListarPreciosProducto(x.ProductoSeleccionado.IdProducto))
                {
                    
                    cmbMedida.Items.Add(ELEMENTO.NombreMedida);
                    
                }
            }
        }

        private void rbnBoleta_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnFactura.Checked == true)
            {
                lblTipo.Text = "FACTURA";
            }
            else
            {
                if (rbnGuia.Checked==true)
                {
                    lblTipo.Text = "GUIA DE REMISION";
                }
                else
                {
                    lblTipo.Text = "BOLETA DE VENTA";    
                }
                
            }
        }

        private void rbnGuia_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnFactura.Checked == true)
            {
                lblTipo.Text = "FACTURA";
            }
            else
            {
                if (rbnGuia.Checked == true)
                {
                    lblTipo.Text = "GUIA DE REMISION";
                }
                else
                {
                    lblTipo.Text = "BOLETA DE VENTA";
                }

            }
        }

        private void cmbMedida_SelectedValueChanged(object sender, EventArgs e)
        {
            foreach (clsPrecio ELEMENTO in clsPrecio.ListarPreciosProductoMedida(IdProd,cmbMedida.SelectedItem.ToString()))
                {

                    txtPVenta.Text = ELEMENTO.Precio.ToString();
                    
                }        
        }



    }
}
