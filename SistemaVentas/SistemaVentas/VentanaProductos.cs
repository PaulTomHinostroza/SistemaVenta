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
    public partial class VentanaProductos : Form
    {
        public VentanaProductos()
        {
            InitializeComponent();
        }

        private void btnInsertarMedida_Click(object sender, EventArgs e)
        {
            RegistroMedida x;
            x = new RegistroMedida();
            x.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistroProducto x;
            x = new RegistroProducto();
            x.ShowDialog();
        }

    }
}
