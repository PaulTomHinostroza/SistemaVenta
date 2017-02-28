using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class clsProducto
    {
        private clsMedida _Medida;
        private int _IdProducto;
        private string _NombreProd;
        private string _MarcaProd;
        private decimal _PrecioVenta;
        private decimal _PrecioVentaUnitario;
        private decimal _PrecioCompra;
        private int _CantidadProd;
        private string _DescripcionProd;

        public clsProducto(string parNombre, string parMarca, decimal parPrecioVenta, decimal parPrecioCompra,
                            int parCantidad, clsMedida parMedida)
        {
            NombreProd = parNombre;
            MarcaProd = parMarca;
            PrecioVenta = parPrecioVenta;
            PrecioCompra = parPrecioCompra;
            CantidadProd = parCantidad;
            Medida = parMedida;
        }

        public clsProducto(int parIdProducto,string parNombre, string parMarca, decimal parPrecioVenta, decimal parPrecioCompra,
                            int parCantidad, clsMedida parMedida)
        {
            NombreProd = parNombre;
            MarcaProd = parMarca;
            PrecioVenta = parPrecioVenta;
            PrecioCompra = parPrecioCompra;
            CantidadProd = parCantidad;
            Medida = parMedida;
            IdProducto = parIdProducto;
        }

        public int IdProducto
        {
            get { return _IdProducto; }
            set { _IdProducto = value; }
        }
        
        public string NombreProd
        {
            get { return _NombreProd; }
            set { _NombreProd = value; }
        }

        public string MarcaProd
        {
            get { return _MarcaProd; }
            set { _MarcaProd = value; }
        }

        public decimal PrecioVenta
        {
            get { return _PrecioVenta; }
            set { _PrecioVenta = value; }
        }

        public decimal PrecioVentaUnitario
        {
            get { return _PrecioVentaUnitario; }
            set { _PrecioVentaUnitario = value; }
        }

        public decimal PrecioCompra
        {
            get { return _PrecioCompra; }
            set { _PrecioCompra = value; }
        }

        public int CantidadProd
        {
            get { return _CantidadProd; }
            set { _CantidadProd = value; }
        }

        public string DescripcionProd
        {
            get { return _DescripcionProd; }
            set { _DescripcionProd = value; }
        }

        public clsMedida Medida
        {
            get { return _Medida; }
            set { _Medida = value; }
        }

        public void InsertarProducto()
        {
            SqlConnection conexion;
            conexion = new SqlConnection("SERVER=ADMIN\\SQLEXPRESS;DATABASE=CentroComercial;USER=sa;PWD=continental");
            SqlCommand comando1;
            comando1 = new SqlCommand("usp_Producto_Insertar", conexion);
            comando1.CommandType = System.Data.CommandType.StoredProcedure;
            comando1.Parameters.AddWithValue("@parNombre_Prod", NombreProd);
            comando1.Parameters.AddWithValue("@parMarca_Prod", MarcaProd);
            comando1.Parameters.AddWithValue("@parPrecioVenta_Prod", PrecioVenta);
            comando1.Parameters.AddWithValue("@parPrecioVenta_Prod", PrecioVenta);
            comando1.Parameters.AddWithValue("@parPrecioCompra_Prod", PrecioCompra);
            comando1.Parameters.AddWithValue("@parCantidad_Prod", CantidadProd);
            comando1.Parameters.AddWithValue("@parIdMedida", Medida.IdMedida);
            if (string.IsNullOrEmpty(DescripcionProd))
            {
                comando1.Parameters.AddWithValue("@parDescripccion_Prod", DBNull.Value);
            }
            else
            {
                comando1.Parameters.AddWithValue("@parDescripccion_Prod", DescripcionProd);
            }
            conexion.Open();
            comando1.ExecuteNonQuery();
            conexion.Close();
        }

        public static List<clsProducto> Listar_Todos()
        {
            List<clsProducto> x = new List<clsProducto>();
            SqlConnection conexion = new SqlConnection("Server=ADMIN\\SQLEXPRESS;Database=CentroComercial;USER=sa;PWD=continental");
            SqlCommand cmd = new SqlCommand("usp_Producto_Listar_Todos", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            conexion.Open();
            SqlDataReader contenedor;
            contenedor = cmd.ExecuteReader();

            while (contenedor.Read()==true)
            {
                clsMedida y;
                y=new clsMedida(contenedor["Nombre"].ToString());

                clsProducto MiObjeto;
                MiObjeto = new clsProducto(Convert.ToInt16(contenedor["IdProducto"]), contenedor["Nombre_Prod"].ToString(), contenedor["Marca_Prod"].ToString(), Convert.ToDecimal(contenedor["PrecioVenta_Prod"]), Convert.ToDecimal(contenedor["PrecioCompra_Prod"]), Convert.ToInt16(contenedor["Cantidad_Prod"]), y);

                x.Add(MiObjeto);
            }
            conexion.Close();
            return x;
        }
    }
}
