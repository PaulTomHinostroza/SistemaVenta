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
    public partial class LoginEmpleado : Form
    {
        public LoginEmpleado()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            clsEmpleado MiUsuario = clsEmpleado.Validar(txtUsuario.Text, txtContraseña.Text);
            if (MiUsuario == null)
            {
                MessageBox.Show("El usuario y/o clave es incorrecto.");
            }
            else
            {
                mdlVariables.MiUsuarioConectado = MiUsuario;
                Close();
            }
        }
    }
}
