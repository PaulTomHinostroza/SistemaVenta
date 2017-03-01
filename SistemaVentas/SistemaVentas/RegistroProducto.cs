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
        
        public RegistroProducto()
        {
            InitializeComponent();
        }


        private void btGuardar_Click(object sender, EventArgs e)
        {
            clsProducto nuevoProducto;
            nuevoProducto = new clsProducto(txtNombre.Text,txtMarca.Text);
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

        }
    }
}
