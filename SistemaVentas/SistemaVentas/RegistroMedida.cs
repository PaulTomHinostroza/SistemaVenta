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
    public partial class RegistroMedida : Form
    {
        public RegistroMedida()
        {
            InitializeComponent();
        }

        private void RegistroMedida_Load(object sender, EventArgs e)
        {

        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            clsMedida nuevaMedida;
            nuevaMedida = new clsMedida(txtNombre.Text);
            nuevaMedida.InsertarMedida();
            MessageBox.Show("Medida Registrado");
        }
    }
}
