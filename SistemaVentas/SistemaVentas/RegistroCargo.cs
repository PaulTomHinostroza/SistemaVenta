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
    public partial class RegistroCargo : Form
    {
        public RegistroCargo()
        {
            InitializeComponent();
        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            clsCargo nuevoCargo;
            nuevoCargo = new clsCargo(txtNombre.Text);
            nuevoCargo.DescripcionCar = txtDescripcion.Text;
            nuevoCargo.InsertarCargo();
            MessageBox.Show("Cargo Registrado");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
