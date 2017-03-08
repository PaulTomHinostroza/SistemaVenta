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
    public partial class VentanaCliente : Form
    {
        public VentanaCliente()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistroCliente x;
            x = new RegistroCliente();
            x.ShowDialog();

        }

        private void btnreportcli_Click(object sender, EventArgs e)
        {
            ReporteCliente x;
            x = new ReporteCliente();
            x.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            lstvClientes.Items.Clear(); 
            int contador = 1;
            foreach (clsCliente ELEMENTO in clsCliente.ListarCliente())
            {

                lstvClientes.Items.Add(contador.ToString());
                lstvClientes.Items[contador - 1].SubItems.Add(ELEMENTO.NombresCli);
                lstvClientes.Items[contador - 1].SubItems.Add(ELEMENTO.ApellidosCli);
                lstvClientes.Items[contador - 1].SubItems.Add(ELEMENTO.DNICli);
                lstvClientes.Items[contador - 1].SubItems.Add(ELEMENTO.DireccionCli);
                lstvClientes.Items[contador - 1].SubItems.Add(ELEMENTO.TelefonoCli);
                lstvClientes.Items[contador - 1].SubItems.Add(ELEMENTO.GeneroCli.ToString());
                lstvClientes.Items[contador - 1].SubItems.Add(ELEMENTO.RUCCli);
                lstvClientes.Items[contador - 1].SubItems.Add(ELEMENTO.EmailCli);
                lstvClientes.Items[contador - 1].SubItems.Add(ELEMENTO.FechaInscripcion.ToString());
                if (contador % 2 == 0)
                {
                    lstvClientes.Items[contador - 1].BackColor = Color.Khaki;
                }

                contador = contador + 1;
            }
        }
    }
}
