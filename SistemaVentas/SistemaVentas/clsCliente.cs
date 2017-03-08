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
            set
            {
                if (value.Length > 60)
                {
                    throw new Exception("El nombre del cliente no debe exceder mas de 60 caracteres");
                }
                else
                {
                    _NombresCli = value.ToUpper();
                }
            }
        }

        public string ApellidosCli
        {
            get { return _ApellidosCli; }
            set
            {
                if (value.Length > 70)
                {
                    throw new Exception("El apellido del cliente no debe exceder mas de 70 caracteres");
                }
                else
                {
                    _ApellidosCli = value.ToUpper();
                }
            }
        }
        public string DNICli
        {
            get { return _DNICli; }
            set
            {
                if (value.Length !=8)
                {
                    throw new Exception("El DNI del cliente no debe exceder mas de 8 caracteres");
                }
                else
                {
                    _DNICli = value.ToUpper();
                } 
            }
        }

        public string DireccionCli
        {
            get { return _DireccionCli; }
            set
            {
                if (value.Length > 80)
                {
                    throw new Exception("La direccion del cliente no debe exceder mas de 80 caracteres");
                }
                else
                {
                    _DireccionCli = value.ToUpper();
                }
            }
        }
        public string TelefonoCli
        {
            get { return _TelefonoCli; }
            set
            {

                if (value.Length != 9)
                {
                    throw new Exception("El telefono del cliente  debe tener 9 caracteres");
                }
                else
                {
                    _TelefonoCli = value.ToUpper();
                }
                
            }
        }


        public char GeneroCli
        {
            get { return _GeneroCli; }
            set { _GeneroCli = value; }
        }

        public string RUCCli
        {
            get { return _RUCCli; }
            set
            {
                if (value.Length > 10)
                {
                    throw new Exception("El RUC del cliente debe tener  10 caracteres");
                }
                else
                {
                    _RUCCli = value.ToUpper();
                }
            }
        }

        public string EmailCli
        {
            get { return _EmailCli; }
            set
            {
                if (value.Length > 30)
                {
                    throw new Exception("El Correo electronico del cliente no debe exceder mas de 30 caracteres");
                }
                else
                {
                    _EmailCli = value.ToUpper();
                }
            }

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
