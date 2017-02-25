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
    public partial class VentanaEmpleado : Form
    {
        public VentanaEmpleado()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lstvDatos.Items.Clear();
            RegistroEmpleado x;
            x=new RegistroEmpleado();
            x.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            lstvDatos.Items.Clear();
            int contador = 1;
            foreach (clsEmpleado elemento in clsEmpleado.Listar())
            {
                lstvDatos.Items.Add(contador.ToString());
                lstvDatos.Items[contador-1].SubItems.Add(elemento.IdEmpleado.ToString());
                lstvDatos.Items[contador - 1].SubItems.Add(elemento.NombresEmp);
                lstvDatos.Items[contador - 1].SubItems.Add(elemento.ApellidosEmp);
                lstvDatos.Items[contador - 1].SubItems.Add(elemento.DNIEmp);
                lstvDatos.Items[contador - 1].SubItems.Add(elemento.TelefonoEmp);
                lstvDatos.Items[contador - 1].SubItems.Add(elemento.GeneroEmp.ToString());
                lstvDatos.Items[contador - 1].SubItems.Add(elemento.EmailEmp);
                lstvDatos.Items[contador - 1].SubItems.Add(elemento.FechaNacEmp.ToString());
                lstvDatos.Items[contador - 1].SubItems.Add(elemento.CargoL.ToString());
                contador++;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

   
    }
}
