using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public class clsMedida
    {
        private int _IdMedida;
        private string _Nombre;

        public clsMedida(string pNombre)
        {
            Nombre = pNombre;
        }
        public clsMedida(string pNombre, int parIdMedida)
        {
            Nombre = pNombre;
            IdMedida = parIdMedida;
        }
        public int IdMedida
        {
            get { return _IdMedida; }
            set { _IdMedida = value; }
        }

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public void InsertarMedida()
        {
            SqlConnection conexion = new SqlConnection("Server=ADMIN\\SQLEXPRESS;Database=CentroComercial;USER=sa;PWD=continental");
            SqlCommand cmd = new SqlCommand("usp_Medida_Insertar", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@parNombre", Nombre);
            conexion.Open();
            cmd.ExecuteReader();
            conexion.Close();
        }

        public static List<clsMedida> Listar()
        {
            List<clsMedida> x = new List<clsMedida>();
            SqlConnection conexion = new SqlConnection("Server=ADMIN\\SQLEXPRESS;Database=CentroComercial;USER=sa;PWD=continental");
            SqlCommand cmd = new SqlCommand("usp_Medida_Listar_Todos", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            conexion.Open();
            SqlDataReader contenedor;
            contenedor = cmd.ExecuteReader();

            while (contenedor.Read() == true)
            {
                clsMedida MiObjeto;
                MiObjeto = new clsMedida(contenedor["Nombre"].ToString(),Convert.ToInt32(contenedor["IdMedida"]));

                x.Add(MiObjeto);
            }
            conexion.Close();
            return x;
        }
    }
}
