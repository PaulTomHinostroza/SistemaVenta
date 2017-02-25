using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class clsProveedor
    {
        private string _NombreProv;
        private string _DireccionProv;
        private string _TelefonoProv;
        private string _RUCProv;
        private string _EmailProv;

        public clsProveedor(string parNombreProv, string parDireccionProv,string parTelefonoProv ,string parRUCProv)

        {
            NombreProv = parNombreProv;
            DireccionProv = parDireccionProv;
            TelefonoProv = parTelefonoProv;
            RUCProv = parRUCProv;
        
        }

        public string NombreProv
        {
            get { return _NombreProv; }
            set { _NombreProv = value; }
        }
        public string DireccionProv
        {
            get { return _DireccionProv; }
            set { _DireccionProv = value; }
        }

        public string TelefonoProv
        {
            get { return _TelefonoProv; }
            set { _TelefonoProv = value; }
        }
        public string RUCProv
        {
            get { return _RUCProv; }
            set { _RUCProv = value; }
        }

        public string EmailProv
        {
            get { return _EmailProv; }
            set { _EmailProv = value; }
        }

        public void InsertarProveedor()
        {
            SqlConnection conexion;
            conexion = new SqlConnection("SERVER=ADMIN\\SQLEXPRESS;DATABASE=ElAmigo;USER=sa;PWD=continental");
            SqlCommand comando1;
            comando1 = new SqlCommand("usp_Proveedor_Insertar", conexion);
            comando1.CommandType = System.Data.CommandType.StoredProcedure;
            comando1.Parameters.AddWithValue("@parNombre_Prov", NombreProv);
            comando1.Parameters.AddWithValue("@parDireccion_Prov", DireccionProv);
            comando1.Parameters.AddWithValue("@parTelefono_Prov", TelefonoProv);
            comando1.Parameters.AddWithValue("@parRUC_Prov", RUCProv);
            if (string.IsNullOrEmpty(EmailProv))
            {
                comando1.Parameters.AddWithValue("@parEmail_Prov", DBNull.Value);
            }
            else
            {
                comando1.Parameters.AddWithValue("@parEmail_Prov", EmailProv);
            }

            conexion.Open();
            comando1.ExecuteNonQuery();
            conexion.Close();

        }
    }
}
