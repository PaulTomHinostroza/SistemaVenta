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
    public partial class RegistroProveedor : Form
    {
        public RegistroProveedor()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            clsProveedor NuevoProveedor;
            NuevoProveedor = new clsProveedor(txtNombres.Text, txtDireccion.Text, txtTelefono.Text, txtRUC.Text);
            NuevoProveedor.EmailProv = txtEmail.Text;
            NuevoProveedor.InsertarProveedor();
            MessageBox.Show("Proveedor Registrado");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
