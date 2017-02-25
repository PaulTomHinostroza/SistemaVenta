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
    public partial class RegistroCliente : Form
    {
        public RegistroCliente()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            clsCliente nuevocliente;
            if (rbnMasculino.Checked == true)
            {
                nuevocliente = new clsCliente(txtNombres.Text, txtApellidos.Text, txtDNI.Text, txtDireccion.Text,
                                                'M', txtRUC.Text);
            }
            else
            {
                nuevocliente = new clsCliente(txtNombres.Text, txtApellidos.Text, txtDNI.Text, txtDireccion.Text,
                                                'F', txtRUC.Text);
            }

            nuevocliente.TelefonoCli = txtTelefono.Text;
            nuevocliente.EmailCli = txtEmail.Text;
            nuevocliente.InsertarCliente();
            MessageBox.Show("Cliente Registrado");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
