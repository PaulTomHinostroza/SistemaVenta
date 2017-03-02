using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class clsCliente
    {
        private string _NombresCli;
        private string _ApellidosCli;
        private string _DNICli;
        private string _DireccionCli;
        private string _TelefonoCli;
        private char _GeneroCli;
        private string _RUCCli;
        private string _EmailCli;

        public clsCliente(string parNombresCli, string parApellidosCli,
                          string parDNICli, string parDireccionCli, char parGeneroCli,
                          string parRUCCli)
        {
            NombresCli = parNombresCli;
            ApellidosCli = parApellidosCli;
            DNICli = parDNICli;
            DireccionCli = parDireccionCli;
            GeneroCli = parGeneroCli;
            RUCCli = parRUCCli;
        }

        public string NombresCli
        {
            get { return _NombresCli; }
            set { _NombresCli = value; }
        }

        public string ApellidosCli
        {
            get { return _ApellidosCli; }
            set { _ApellidosCli = value; }
        }
        public string DNICli
        {
            get { return _DNICli; }
            set { _DNICli = value; }
        }

        public string DireccionCli
        {
            get { return _DireccionCli; }
            set { _DireccionCli = value; }
        }
        public string TelefonoCli
        {
            get { return _TelefonoCli; }
            set { _TelefonoCli = value; }
        }


        public char GeneroCli
        {
            get { return _GeneroCli; }
            set { _GeneroCli = value; }
        }

        public string RUCCli
        {
            get { return _RUCCli; }
            set { _RUCCli = value; }
        }

        public string EmailCli
        {
            get { return _EmailCli; }
            set { _EmailCli = value; }

        }

        public void InsertarCliente()
        {
            SqlConnection conexion;
            conexion = new SqlConnection("SERVER=.;DATABASE=CentroComercial;USER=sa;PWD=continental");
            SqlCommand comando1;
            comando1 = new SqlCommand("usp_Cliente_Insertar", conexion);
            comando1.CommandType = System.Data.CommandType.StoredProcedure;

            comando1.Parameters.AddWithValue("@parNombres_Cli", NombresCli);
            comando1.Parameters.AddWithValue("@parApellidos_Cli", ApellidosCli);
            comando1.Parameters.AddWithValue("@parDNI_Cli", DNICli);
            comando1.Parameters.AddWithValue("@parDireccion_Cli", DireccionCli);
            comando1.Parameters.AddWithValue("@parGenero_Cli", GeneroCli);
            comando1.Parameters.AddWithValue("@parRUC_Cli", RUCCli);

            if (string.IsNullOrEmpty(TelefonoCli))
            {
                comando1.Parameters.AddWithValue("@partelefono_Cli", DBNull.Value);
            }
            else
            {
                comando1.Parameters.AddWithValue("@partelefono_Cli", TelefonoCli);
            }

            if (string.IsNullOrEmpty(EmailCli))
            {
                comando1.Parameters.AddWithValue("@parEmail_Cli", DBNull.Value);
            }
            else
            {
                comando1.Parameters.AddWithValue("@parEmail_Cli", EmailCli);
            }

            conexion.Open();
            comando1.ExecuteNonQuery();
            conexion.Close();

        }
    }
}
