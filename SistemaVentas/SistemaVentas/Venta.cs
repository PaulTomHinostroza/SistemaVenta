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
    public partial class Pedido : Form
    {

        public Pedido()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ListarProductoVenta x;
            x = new ListarProductoVenta();
            x.ShowDialog();
        }

        private void Pedido_Load(object sender, EventArgs e)
        {
        }
    }
}
