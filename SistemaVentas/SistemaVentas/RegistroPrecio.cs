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
    public partial class RegistroPrecio : Form
    {
        
        private List<clsMedida> _LasMedidas = new List<clsMedida>();

        public List<clsMedida> LasMedidas
        {
            get { return _LasMedidas; }
            set { _LasMedidas = value; }
        }

        public RegistroPrecio()
        {
            InitializeComponent();
        }

        private void txtProducto_Click(object sender, EventArgs e)
        {
            ListadoProductos x;
            x = new ListadoProductos();
            x.ShowDialog();

            if (x.ProductoSeleccionado == null)
            {
                MessageBox.Show("La búsqueda fue cancelada");
            }
            else
            {
                txtProducto.Text = x.ProductoSeleccionado.NombreProd;
                txtMarca.Text = x.ProductoSeleccionado.MarcaProd;
            }
        }

        private void RegistroPrecio_Load(object sender, EventArgs e)
        {
            cmbMedida.Items.Clear();
            foreach (clsMedida elemento in clsMedida.Listar())
            {
                cmbMedida.Items.Add(elemento.Nombre);
            }

        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            ListadoProductos x;
            x = new ListadoProductos();

            clsPrecio nuevoPrecio;
            nuevoPrecio= new clsPrecio(x.ProductoSeleccionado.IdProducto,LasMedidas[cmbMedida.SelectedIndex],Convert.ToDecimal(nudPrecio.Value));
            nuevoPrecio.InsertarPrecio();
            MessageBox.Show("Precio Registrado");

        }
    }
}