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
    public partial class RegistroProducto : Form
    {
        private List<clsMedida> _Medidas = new List<clsMedida>();

        public List<clsMedida> Medidas
        {
            get { return _Medidas; }
            set { _Medidas = value; }
        }
        public RegistroProducto()
        {
            InitializeComponent();
        }


        private void btGuardar_Click(object sender, EventArgs e)
        {
            clsProducto nuevoProducto;
            nuevoProducto = new clsProducto(txtMarca.Text,txtMarca.Text,Convert.ToDecimal(nudPrecioVenta.Value),Convert.ToDecimal(nudPrecioCompra.Value),Convert.ToInt32(nudCantidad.Value),Medidas[cmbMedida.SelectedIndex]);
            nuevoProducto.DescripcionProd = txtDescripcion.Text;
            nuevoProducto.InsertarProducto();
            MessageBox.Show("Producto Registrado");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RegistroProducto_Load(object sender, EventArgs e)
        {
            Medidas.Clear();
            cmbMedida.Items.Clear();
            foreach (clsMedida elemento in clsMedida.Listar())
            {
                cmbMedida.Items.Add(elemento.Nombre);
                Medidas.Add(elemento);
            }
        }
    }
}
