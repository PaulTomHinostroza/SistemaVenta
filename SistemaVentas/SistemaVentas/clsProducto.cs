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
        
        private int _IdProducto;
        private string _NombreProd;
        private string _MarcaProd;
        private string _DescripcionProd;


        public clsProducto(string parNombre, string parMarca)
        {
            NombreProd = parNombre;
            MarcaProd = parMarca;
        }

        public clsProducto(int parIdProducto,string parNombre, string parMarca )
        {
            NombreProd = parNombre;
            MarcaProd = parMarca;
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

        public string DescripcionProd
        {
            get { return _DescripcionProd; }
            set { _DescripcionProd = value; }
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
                
                clsProducto MiObjeto;
                MiObjeto = new clsProducto(Convert.ToInt16(contenedor["IdProducto"]), contenedor["Nombre_Prod"].ToString(), contenedor["Marca_Prod"].ToString());

                x.Add(MiObjeto);
            }
            conexion.Close();
            return x;
        }
    }
}
