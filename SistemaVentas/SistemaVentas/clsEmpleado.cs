using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class clsEmpleado
    {
        private int _IdEmpleado;
        private clsCargo _Cargo;
        private int _CargoL;

        
        private string _NombresEmp;
        private string _ApellidosEmp;
        private string _DNIEmp;
        private string _TelefonoEmp;
        private char _GeneroEmp;
        private string _EmailEmp;
        private DateTime _FechaNacEmp;

        public clsEmpleado(clsCargo parCargo, string parNombres, string parApellidos, string parDNI,
                            string parTelefono, char parGenero, DateTime parFechaNacimiento)
        {
            Cargo = parCargo;
            NombresEmp = parNombres;
            ApellidosEmp = parApellidos;
            DNIEmp = parDNI;
            TelefonoEmp = parTelefono;
            GeneroEmp = parGenero;
            FechaNacEmp = parFechaNacimiento;
        }

        public clsEmpleado(int parIdEmpleado, string parNombres, string parApellidos, string parDNI,
                            string parTelefono, char parGenero, string parEmail, DateTime parFechaNacimiento, int parCargoL)
        {
            CargoL = parCargoL;
            NombresEmp = parNombres;
            ApellidosEmp = parApellidos;
            DNIEmp = parDNI;
            TelefonoEmp = parTelefono;
            GeneroEmp = parGenero;
            FechaNacEmp = parFechaNacimiento;
            EmailEmp = parEmail;
            IdEmpleado = parIdEmpleado;
        }

        public int IdEmpleado
        {
            get { return _IdEmpleado; }
            set { _IdEmpleado = value; }
        }
        public int CargoL
        {
            get { return _CargoL; }
            set { _CargoL = value; }
        }
    
        public clsCargo Cargo
        {
            get
            {
                return _Cargo;
            }
            set
            {
                _Cargo = value;
            }
        }

        public string NombresEmp
        {
            get { return _NombresEmp; }
            set { _NombresEmp = value; }
        }

        public string ApellidosEmp
        {
            get { return _ApellidosEmp; }
            set { _ApellidosEmp = value; }
        }

        public string DNIEmp
        {
            get { return _DNIEmp; }
            set { _DNIEmp = value; }
        }

        public string TelefonoEmp
        {
            get { return _TelefonoEmp; }
            set { _TelefonoEmp = value; }
        }

        public char GeneroEmp
        {
            get { return _GeneroEmp; }
            set { _GeneroEmp = value; }
        }

        public string EmailEmp
        {
            get { return _EmailEmp; }
            set { _EmailEmp = value; }
        }

        public DateTime FechaNacEmp
        {
            get { return _FechaNacEmp; }
            set { _FechaNacEmp = value; }
        }

        public void InsertarEmpleado()
        {
           
            SqlConnection conexion = new SqlConnection("Server=.;Database=CentroComercial;USER=sa;PWD=continental");
            SqlCommand cmd = new SqlCommand("usp_Empleado_Insertar", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@parNombres_Emp", NombresEmp);
            cmd.Parameters.AddWithValue("@parApellidos_Emp", ApellidosEmp);
            cmd.Parameters.AddWithValue("@parDNI_Emp", DNIEmp);
            cmd.Parameters.AddWithValue("@parTelefono_Emp", TelefonoEmp);
            cmd.Parameters.AddWithValue("@parGenero_Emp", GeneroEmp);
            cmd.Parameters.AddWithValue("@parFecha_Nac_Emp", FechaNacEmp);
            cmd.Parameters.AddWithValue("@parIdCargo",Cargo.IdCargo );
            if (string.IsNullOrEmpty(EmailEmp))
            {
                cmd.Parameters.AddWithValue("@parEmail_Emp", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@parEmail_Emp", EmailEmp);
            }
            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public static List<clsEmpleado> Listar()
        {
            List<clsEmpleado> x = new List<clsEmpleado>();
            SqlConnection conexion = new SqlConnection("Server=.;Database=CentroComercial;USER=sa;PWD=continental");
            SqlCommand cmd = new SqlCommand("usp_Empleado_Listar_Todos", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            conexion.Open();
            SqlDataReader contenedor;
            contenedor = cmd.ExecuteReader();
            while (contenedor.Read()==true)
            {
                clsEmpleado MiObjeto;
                MiObjeto = new clsEmpleado(Convert.ToInt32(contenedor["IdEmpleado"]), contenedor["Nombres_Emp"].ToString(),
                                        contenedor["Apellidos_Emp"].ToString(), contenedor["DNI_Emp"].ToString(),
                                        contenedor["Telefono_Emp"].ToString(), Convert.ToChar(contenedor["Genero_Emp"]), contenedor["Email_Emp"].ToString(),
                                        Convert.ToDateTime(contenedor["Fecha_Nac_Emp"]), Convert.ToInt32(contenedor["IdCargo"]));

                x.Add(MiObjeto);
            }
            conexion.Close();
            return x;
        }

        public void ActualizarEmpleado()
        {
            SqlConnection conexion = new SqlConnection("Server=.;Database=CentroComercial;USER=sa;PWD=continental");
            SqlCommand cmd = new SqlCommand("usp_Empleado_Actualizar_Datos", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@parNombres_Emp", NombresEmp);
            cmd.Parameters.AddWithValue("@parApellidos_Emp", ApellidosEmp);
            cmd.Parameters.AddWithValue("@parDNI_Emp", DNIEmp);
            cmd.Parameters.AddWithValue("@parTelefono_Emp", TelefonoEmp);
            cmd.Parameters.AddWithValue("@parGenero_Emp", GeneroEmp);
            cmd.Parameters.AddWithValue("@parFecha_Nac_Emp", FechaNacEmp);
            cmd.Parameters.AddWithValue("@parIdCargo", Cargo.IdCargo);
            if (string.IsNullOrEmpty(EmailEmp))
            {
                cmd.Parameters.AddWithValue("@parEmail_Emp", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@parEmail_Emp", EmailEmp);
            }
            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
