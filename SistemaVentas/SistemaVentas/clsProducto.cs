using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class clsProducto
    {
        private clsMedida _Medida;
        private string _NombreProd;
        private string _MarcaProd;
        private decimal _PrecioVenta;
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

    }
}
