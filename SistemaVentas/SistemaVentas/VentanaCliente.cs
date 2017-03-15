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

        private clsCliente _ClienteSeleccionado;

        public clsCliente ClienteSeleccionado
        {
            get { return _ClienteSeleccionado; }
            set { _ClienteSeleccionado = value; }
        }

        private List<clsCliente> _ClienteEncontrado = new List<clsCliente>();

        public List<clsCliente> ClienteEncontrado
        {
            get { return _ClienteEncontrado; }
            set { _ClienteEncontrado = value; }
        }


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
            ClienteEncontrado.Clear();
            lstvDatos.Items.Clear(); 
            int contador = 1;
            foreach (clsCliente ELEMENTO in clsCliente.ListarCliente())
            {

                ClienteEncontrado.Add(ELEMENTO);
                lstvDatos.Items.Add(contador.ToString());
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.NombresCli);
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.ApellidosCli);
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DNICli);
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DireccionCli);
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.TelefonoCli);
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.GeneroCli.ToString());
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.RUCCli);
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.FechaInscripcion.ToString());
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.EmailCli);
                if (contador % 2 == 0)
                {
                    lstvDatos.Items[contador - 1].BackColor = Color.Khaki;
                }

                contador = contador + 1;
            }
        }

        private void VentanaCliente_Load(object sender, EventArgs e)
        {
            txtApellidos.Visible = false;
            txtDNI.Visible = false;
            txtNombres.Visible = false;
        }

        private void txtNombres_TextChanged_1(object sender, EventArgs e)
        {


            if (txtNombres.Text.Length >= 3)
            {
                ClienteEncontrado.Clear();
                lstvDatos.Items.Clear();
                int contador = 1;
                foreach (clsCliente ELEMENTO in clsCliente.Buscar_PorNombres(txtNombres.Text))
                {
                    ClienteEncontrado.Add(ELEMENTO);
                    lstvDatos.Items.Add(contador.ToString());
                    lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.NombresCli);
                    lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.ApellidosCli);
                    lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DNICli);
                    lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DireccionCli);
                    lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.TelefonoCli);
                    lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.GeneroCli.ToString());
                    lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.RUCCli);
                    lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.FechaInscripcion.ToString());
                    lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.EmailCli);

                    if (contador % 2 == 0)
                    {
                        lstvDatos.Items[contador - 1].BackColor = Color.Khaki;
                    }
                    contador = contador + 1;
                }
            }

        }

        private void rbnNombres_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rbnNombres.Checked == true)
            {
                txtNombres.Visible = true;
                txtApellidos.Visible = false;
                txtDNI.Visible = false;
            }
            else if (rbnApellidos.Checked == true)
            {
                txtApellidos.Visible = true;
                txtNombres.Visible = false;
                txtDNI.Visible = false;
            }
            else if (rbnDNI.Checked == true)
            {
                txtDNI.Visible = true;
                txtNombres.Visible = false;
                txtApellidos.Visible = false;
            }
        }

        private void rbnApellidos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnNombres.Checked == true)
            {
                txtNombres.Visible = true;
                txtApellidos.Visible = false;
                txtDNI.Visible = false;
            }
            else if (rbnApellidos.Checked == true)
            {
                txtApellidos.Visible = true;
                txtNombres.Visible = false;
                txtDNI.Visible = false;
            }
            else if (rbnDNI.Checked == true)
            {
                txtDNI.Visible = true;
                txtNombres.Visible = false;
                txtApellidos.Visible = false;
            }
        }

        private void rbnDNI_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnNombres.Checked == true)
            {
                txtNombres.Visible = true;
                txtApellidos.Visible = false;
                txtDNI.Visible = false;
            }
            else if (rbnApellidos.Checked == true)
            {
                txtApellidos.Visible = true;
                txtNombres.Visible = false;
                txtDNI.Visible = false;
            }
            else if (rbnDNI.Checked == true)
            {
                txtDNI.Visible = true;
                txtNombres.Visible = false;
                txtApellidos.Visible = false;
            }
        }

        private void txtApellidos_TextChanged_1(object sender, EventArgs e)
        {
            if (txtApellidos.Text.Length >= 3)
            {
                ClienteEncontrado.Clear();
                lstvDatos.Items.Clear();
                int contador = 1;
                foreach (clsCliente ELEMENTO in clsCliente.Buscar_PorApellido(txtApellidos.Text))
                {
                    ClienteEncontrado.Add(ELEMENTO);
                    lstvDatos.Items.Add(contador.ToString());
                    lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.NombresCli);
                    lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.ApellidosCli);
                    lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DNICli);
                    lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DireccionCli);
                    lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.TelefonoCli);
                    lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.GeneroCli.ToString());
                    lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.RUCCli);
                    lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.FechaInscripcion.ToString());
                    lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.EmailCli);

                    if (contador % 2 == 0)
                    {
                        lstvDatos.Items[contador - 1].BackColor = Color.Khaki;
                    }
                    contador = contador + 1;
                }
            }
        }

        private void txtDNI_TextChanged_1(object sender, EventArgs e)
        {
            if (txtDNI.Text.Length >= 3)
            {
                ClienteEncontrado.Clear();
                lstvDatos.Items.Clear();
                int contador = 1;
                foreach (clsCliente ELEMENTO in clsCliente.Buscar_PorDNI(txtDNI.Text))
                {
                    ClienteEncontrado.Add(ELEMENTO);
                    lstvDatos.Items.Add(contador.ToString());
                    lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.NombresCli);
                    lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.ApellidosCli);
                    lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DNICli);
                    lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DireccionCli);
                    lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.TelefonoCli);
                    lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.GeneroCli.ToString());
                    lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.RUCCli);
                    lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.FechaInscripcion.ToString());
                    lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.EmailCli);

                    if (contador % 2 == 0)
                    {
                        lstvDatos.Items[contador - 1].BackColor = Color.Khaki;
                    }
                    contador = contador + 1;
                }
            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            ClienteSeleccionado = null;
        }


        private void lstvDatos_DoubleClick(object sender, EventArgs e)
        {
            ClienteSeleccionado = ClienteEncontrado[lstvDatos.SelectedItems[0].Index];
            Close();
        }



    }
}
