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
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("El nombre del Producto no debe quedar vacío.");
                }
                else if (value.Length > 30)
                {
                    throw new Exception("El nombre del Producto no puede exceder mas de  30 caracteres");
                }
                else
                {
                    _NombreProd = value.ToUpper();
                }
            }
        }

        public string MarcaProd
        {
            get { return _MarcaProd; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("La marca del producto no debe quedar vacio.");
                }
                else if (value.Length > 20)
                {
                    throw new Exception("La marca del producto no debe exceder mas de 20 caracteres");
                }
                else
                {
                    _MarcaProd = value.ToUpper();
                }
            }
        }

        public string DescripcionProd
        {
            get { return _DescripcionProd; }
            set { 
                  if (value.Length > 100)
                  {
                     throw new Exception("La descripccion del producto no debe exceder mas de 100 caracteres");
                  }
                   else
                  {
                     _DescripcionProd = value.ToUpper();
                  }
                 }
        }

        public void InsertarProducto()
        {
            SqlConnection conexion;
            conexion = new SqlConnection(mdlVariables.CadenaDeConexion);
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
            SqlConnection conexion = new SqlConnection(mdlVariables.CadenaDeConexion);
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

        public static List<clsProducto> Buscar_PorNombre(string parametroNombre)
        {
            List<clsProducto> x = new List<clsProducto>();

            SqlConnection conexion;
            conexion = new SqlConnection(mdlVariables.CadenaDeConexion);

            SqlCommand comando;
            comando = new SqlCommand("usp_Producto_Buscar_PorNombre", conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@parNombre", parametroNombre);
            conexion.Open();
            SqlDataReader contenedor;
            contenedor = comando.ExecuteReader();
            while (contenedor.Read() == true)
            {
                clsProducto MiObjeto;
                MiObjeto = new clsProducto(Convert.ToInt16(contenedor["IdProducto"]), contenedor["Nombre_Prod"].ToString(), contenedor["Marca_Prod"].ToString());

                if (contenedor["Descripccion_Prod"] != DBNull.Value)
                {
                    MiObjeto.DescripcionProd = contenedor["Descripccion_Prod"].ToString();
                }

                x.Add(MiObjeto);
            }
            conexion.Close();

            return x;
        }

        public static List<clsProducto> Buscar_PorMarca(string parametroMarca)
        {
            List<clsProducto> x = new List<clsProducto>();

            SqlConnection conexion;
            conexion = new SqlConnection(mdlVariables.CadenaDeConexion);

            SqlCommand comando;
            comando = new SqlCommand("usp_Producto_Buscar_PorMarca", conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@parMarca", parametroMarca);
            conexion.Open();
            SqlDataReader contenedor;
            contenedor = comando.ExecuteReader();
            while (contenedor.Read() == true)
            {
                clsProducto MiObjeto;
                MiObjeto = new clsProducto(Convert.ToInt16(contenedor["IdProducto"]), contenedor["Nombre_Prod"].ToString(), contenedor["Marca_Prod"].ToString());

                if (contenedor["Descripccion_Prod"] != DBNull.Value)
                {
                    MiObjeto.DescripcionProd = contenedor["Descripcion_Prod"].ToString();
                }

                x.Add(MiObjeto);
            }
            conexion.Close();

            return x;
        }
    }
}
