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
    public partial class RegistroEmpleado : Form
    {
        private List<clsCargo> _LosCargos = new List<clsCargo>();

        public List<clsCargo> LosCargos
        {
            get { return _LosCargos; }
            set { _LosCargos = value; }
        }
        public RegistroEmpleado()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                clsEmpleado nuevoEmpleado;
                if (rbMasculino.Checked == true)
                {
                    nuevoEmpleado = new clsEmpleado(LosCargos[cmbCargo.SelectedIndex], txtNombres.Text,
                                              txtApellidos.Text, txtDNI.Text, txtTelefono.Text,
                                              'M', Convert.ToDateTime(dtpFechaNacimiento.Value.Date));
                }
                else
                {
                    nuevoEmpleado = new clsEmpleado(LosCargos[cmbCargo.SelectedIndex], txtNombres.Text,
                                              txtApellidos.Text, txtDNI.Text, txtTelefono.Text,
                                              'F', Convert.ToDateTime(dtpFechaNacimiento.Value.Date));

                }
                nuevoEmpleado.EmailEmp = txtEmail.Text;
                nuevoEmpleado.InsertarEmpleado();
                MessageBox.Show("Empleado Registrado");
            }
            catch (Exception ErrorRegEm)
            {

                MessageBox.Show(ErrorRegEm.Message);
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RegistroEmpleado_Load(object sender, EventArgs e)
        {
            
            LosCargos.Clear();
            cmbCargo.Items.Clear();
            foreach (clsCargo elemento in clsCargo.Listar())
            {              
                cmbCargo.Items.Add(elemento.NombreCar);
                LosCargos.Add(elemento);
            }
        }

      
    }
}
