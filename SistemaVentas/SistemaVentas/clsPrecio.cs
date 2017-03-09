using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class clsPrecio
    {
        private clsProducto _IdProducto;
        private clsMedida _IdMedida;
        private decimal _Precio;
        private int _IdProductoInt;

        public int IdProductoInt
        {
            get { return _IdProductoInt; }
            set { _IdProductoInt = value; }
        }

        public clsPrecio(clsProducto parIdProducto, clsMedida parIdMedida, decimal parPrecio)
        {
            IdProducto = parIdProducto;
            IdMedida = parIdMedida;
            Precio = parPrecio;
        }

        public clsPrecio(int parIdProductoInt, clsMedida parIdMedida, decimal parPrecio)
        {
            IdProductoInt = parIdProductoInt;
            IdMedida = parIdMedida;
            Precio = parPrecio;
        }

        public clsProducto IdProducto
        {
            get { return _IdProducto; }
            set { _IdProducto = value; }
        }

        public clsMedida IdMedida
        {
            get { return _IdMedida; }
            set { _IdMedida = value; }
        }

        public decimal Precio
        {
            get { return _Precio; }
            set { _Precio = value; }
        }

        public void InsertarPrecio()
        {
            SqlConnection conexion = new SqlConnection(mdlVariables.CadenaDeConexion);
            SqlCommand cmd = new SqlCommand("usp_Precio_Insertar", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@parIdMedida",IdMedida.IdMedida);
            cmd.Parameters.AddWithValue("@parIdProducto", IdProductoInt);
            cmd.Parameters.AddWithValue("@parPrecio", Precio);
            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}