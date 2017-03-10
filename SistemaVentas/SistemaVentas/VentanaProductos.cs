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
        private clsProducto _ProductoSeleccionado;

        public clsProducto ProductoSeleccionado
        {
            get { return _ProductoSeleccionado; }
            set { _ProductoSeleccionado = value; }
        }

        private List<clsProducto> _ProductosEncontrados = new List<clsProducto>();

        public List<clsProducto> ProductosEncontrados
        {
            get { return _ProductosEncontrados; }
            set { _ProductosEncontrados = value; }
        }

        public VentanaProductos()
        {
            InitializeComponent();
        }

        private void btnInsertarMedida_Click_1(object sender, EventArgs e)
        {
            RegistroMedida x;
            x = new RegistroMedida();
            x.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            RegistroProducto x;
            x = new RegistroProducto();
            x.ShowDialog();
        }

        private void VentanaProductos_Load(object sender, EventArgs e)
        {
            txtMarca.Visible = false;
            txtNombre.Visible = false;
        }

        private void rbnNombre_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rbnMarca.Checked == true)
            {
                txtMarca.Visible = true;
                txtNombre.Visible = false;
            }
            else if (rbnNombre.Checked == true)
            {
                txtMarca.Visible = false;
                txtNombre.Visible = true;
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text.Length >= 3)
            {
                ProductosEncontrados.Clear();
                lstvDatos.Items.Clear();
                int contador = 1;
                foreach (clsProducto ELEMENTO in clsProducto.Buscar_PorNombre(txtNombre.Text))
                {
                    ProductosEncontrados.Add(ELEMENTO);
                    lstvDatos.Items.Add(contador.ToString());
                    lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.NombreProd);
                    lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.MarcaProd);
                    lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DescripcionProd);

                    if (contador % 2 == 0)
                    {
                        lstvDatos.Items[contador - 1].BackColor = Color.Khaki;
                    }
                    contador = contador + 1;
                }
                
            }


        }

        private void txtMarca_TextChanged(object sender, EventArgs e)
        {
            ProductosEncontrados.Clear();
            lstvDatos.Items.Clear();
            int contador = 1;
            foreach (clsProducto ELEMENTO in clsProducto.Buscar_PorMarca(txtMarca.Text))
            {
                ProductosEncontrados.Add(ELEMENTO);
                lstvDatos.Items.Add(contador.ToString());
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.NombreProd);
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.MarcaProd);
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DescripcionProd);

                if (contador % 2 == 0)
                {
                    lstvDatos.Items[contador - 1].BackColor = Color.Khaki;
                }
                contador = contador + 1;
            }
        }

        

        private void rbnMarca_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rbnMarca.Checked == true)
            {
                txtMarca.Visible = true;
                txtNombre.Visible = false;
            }
            else if (rbnNombre.Checked == true)
            {
                txtMarca.Visible = false;
                txtNombre.Visible = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ProductoSeleccionado = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegistroPrecio x;
            x = new RegistroPrecio();
            x.ShowDialog();
        }

        private void lstvDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductoSeleccionado = ProductosEncontrados[lstvDatos.SelectedItems[0].Index];

            lstvPrecio.Items.Clear();
            int contador = 1;
            foreach (clsPrecio ELEMENTO in clsPrecio.ListarPreciosProducto(ProductoSeleccionado.IdProducto))
            {
                
                lstvPrecio.Items.Add(ELEMENTO.NombreMedida);
                lstvPrecio.Items[contador - 1].SubItems.Add(ELEMENTO.Precio.ToString());

                if (contador % 2 == 0)
                {
                    lstvPrecio.Items[contador - 1].BackColor = Color.DarkCyan;
                }
                contador = contador + 1;
            }
        }

        private void lstvDatos_DoubleClick(object sender, EventArgs e)
        {
            ProductoSeleccionado = ProductosEncontrados[lstvDatos.SelectedItems[0].Index];
            Close();
        }

       




    }
}
