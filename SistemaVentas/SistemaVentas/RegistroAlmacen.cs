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
    public partial class RegistroAlmacen : Form
    {
        public RegistroAlmacen()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            clsAlmacen nuevoAlmacen;
            nuevoAlmacen = new clsAlmacen(txtDireccion.Text, txtTelefono.Text);
            nuevoAlmacen.InsertarAlmacen();
            MessageBox.Show("Almacen Registrado");
        }
    }
}
