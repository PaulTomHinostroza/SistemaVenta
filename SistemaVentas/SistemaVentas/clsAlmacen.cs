using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class clsAlmacen
    {
        private int _CodigoAlmacen;
        private string _Direccion;
        private string _Telefono;

        public clsAlmacen(string parDireccion, string parTelefono)
        {
            Direccion = parDireccion;
            Telefono = parTelefono;
        }

        public int CodigoAlmacen
        {
            get { return _CodigoAlmacen; }
            set { _CodigoAlmacen = value; }
        }

        public string Direccion
        {
            get { return _Direccion; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("La direccion no debe quedar vacio");
                }
                else if (value.Length > 80)
                {
                    throw new Exception("La direccion no puede contener mas de 80 caracteres");
                }
                else
                {
                    _Direccion = value.ToUpper();
                }
            }
        }

        public string Telefono
        {
            get { return _Telefono; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("El telefono no debe quedar vacio");
                }
                else if (value.Length > 9)
                {
                    throw new Exception("No debe exceder mas de 9");
                }
                else
                {
                    _Telefono = value.ToUpper();
                }
            }
        }

        public void InsertarAlmacen()
        {
            SqlConnection conexion = new SqlConnection("Server=.;Database=CentroComercial;USER=sa;PWD=continental");
            SqlCommand cmd = new SqlCommand("usp_Almacen_Insertar", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@parDireccion", Direccion);
            cmd.Parameters.AddWithValue("@parTelefono", Telefono);
            conexion.Open();
            cmd.ExecuteReader();
            conexion.Close();
        }
    }
}
