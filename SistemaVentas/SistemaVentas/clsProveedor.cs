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
        private string _EmailProv;

        public clsProveedor(string parNombreProv, string parDireccionProv,string parTelefonoProv)

        {
            NombreProv = parNombreProv;
            DireccionProv = parDireccionProv;
            TelefonoProv = parTelefonoProv;
        
        }

        public string NombreProv
        {
            get { return _NombreProv; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("El nombre del cliente no debe quedar vacío.");
                }
                else if (value.Length > 25)
                {
                    throw new Exception("El nombre del Proveedor no debe tener mas de 25 caracteres");
                }
                else
                {
                    _NombreProv = value.ToUpper();
                }
            }
        }
        public string DireccionProv
        {
            get { return _DireccionProv; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("La direccion no debe quedar en blanco");
                }
                else if (value.Length > 35)
                {
                    throw new Exception("La direccion no debe contener mas de 35");
                }
                else
                {
                    _DireccionProv = value.ToUpper();
                }
            }
        }

        public string TelefonoProv
        {
            get { return _TelefonoProv; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("El campo Telefono no bede quedar vacio");
                }
                else if (value.Length != 8)
                {
                    throw new Exception("No debe contener mas de 8 caracteres");
                }
                else
                {
                    _TelefonoProv = value;
                }
            }
        }

        public string EmailProv
        {
            get { return _EmailProv; }
            set
            {
                _EmailProv = value;
            }
        }

        public void InsertarProveedor()
        {
            SqlConnection conexion;
            conexion = new SqlConnection("SERVER=.;DATABASE=CentroComercial;USER=sa;PWD=continental");
            SqlCommand comando1;
            comando1 = new SqlCommand("usp_Proveedor_Insertar", conexion);
            comando1.CommandType = System.Data.CommandType.StoredProcedure;
            comando1.Parameters.AddWithValue("@parNombre_Prov", NombreProv);
            comando1.Parameters.AddWithValue("@parDireccion_Prov", DireccionProv);
            comando1.Parameters.AddWithValue("@parTelefono_Prov", TelefonoProv);
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
