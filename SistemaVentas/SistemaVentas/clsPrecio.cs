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
        private int _IdMedidaInt;
        private string _NombreMedida;

        public string NombreMedida
        {
            get { return _NombreMedida; }
            set { _NombreMedida = value; }
        }

        public int IdMedidaInt
        {
            get { return _IdMedidaInt; }
            set { _IdMedidaInt = value; }
        }

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

        public clsPrecio(int parIdProductoInt, string parNombreMedida, decimal parPrecio)
        {
            IdProductoInt = parIdProductoInt;
            NombreMedida = parNombreMedida;
            Precio = parPrecio;
        }

        public clsPrecio(int parIdProductoInt, int parIdMedidaInt, decimal parPrecio)
        {
            IdProductoInt = parIdProductoInt;
            IdMedidaInt = parIdMedidaInt;
            Precio = parPrecio;
        }

        public clsPrecio(int parIdProductoInt, string parNombreMed)
        {
            IdProductoInt = parIdProductoInt;
            NombreMedida = parNombreMed;
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


        public static List<clsPrecio> ListarPreciosProducto(int parIdProducto)
        {
            List<clsPrecio> x = new List<clsPrecio>();
            SqlConnection conexion = new SqlConnection(mdlVariables.CadenaDeConexion);
            SqlCommand cmd = new SqlCommand("usp_Producto_Listar_MedidaPrecio", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@parIdProducto", parIdProducto);
            conexion.Open();
            SqlDataReader cont;
            cont = cmd.ExecuteReader();
            

            while (cont.Read() == true)
            {
                clsPrecio MiObjeto;
                MiObjeto = new clsPrecio(Convert.ToInt32(cont["IdProducto"]),cont["Nombre"].ToString(), Convert.ToDecimal(cont["Precio"]));
                x.Add(MiObjeto);
            }
            conexion.Close();
            return x;
        }
        
        public static List<clsPrecio> ListarPreciosProductoMedida(int parIdProducto,string parNombreMed)
        {
            List<clsPrecio> x = new List<clsPrecio>();
            SqlConnection conexion = new SqlConnection(mdlVariables.CadenaDeConexion);
            SqlCommand cmd = new SqlCommand("usp_Producto_Listar_PrecioMedida", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@parIdProducto", parIdProducto);
            cmd.Parameters.AddWithValue("@parNombre", parNombreMed);
            conexion.Open();
            SqlDataReader cont;
            cont = cmd.ExecuteReader();

            while (cont.Read() == true)
            {
                clsPrecio MiObjeto;
                MiObjeto = new clsPrecio(Convert.ToInt32(cont["IdProducto"]), cont["Nombre"].ToString(), Convert.ToDecimal(cont["Precio"]));
                x.Add(MiObjeto);
            }
            conexion.Close();
            return x;
        }

        
    }
}