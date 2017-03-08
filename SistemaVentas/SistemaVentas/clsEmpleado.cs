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
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("El nombre del Empleado no debe quedar vacío.");
                }
                else if (value.Length > 30)
                {
                    throw new Exception("El nombre del Empleado no debe tener mas de 30 caracteres");
                }
                else
                {
                    _NombresEmp = value.ToUpper();
                }
            }
        }

        public string ApellidosEmp
        {
            get { return _ApellidosEmp; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("El Apellido  del Empleado no debe quedar vacío.");
                }
                else if (value.Length > 60)
                {
                    throw new Exception("El apellido del Empleado no debe tener mas de 60 caracteres");
                }
                else
                {
                    _ApellidosEmp = value.ToUpper();
                }
            }
        }

        public string DNIEmp
        {
            get { return _DNIEmp; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("El DNI  del Empleado no debe quedar vacío.");
                }
                else if (value.Length != 8)
                {
                    throw new Exception("El DNI del Empleado  debe tener  8 caracteres");
                }
                else
                {
                    _DNIEmp = value.ToUpper();
                }
            }
        }

        public string TelefonoEmp
        {
            get { return _TelefonoEmp; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("El telefono del Empleado no debe quedar vacío.");
                }
                else if (value.Length != 9)
                {
                    throw new Exception("El telefono del Empleado  debe tener  9 caracteres");
                }
                else
                {
                    _TelefonoEmp = value.ToUpper();
                }
            }
        }

        public char GeneroEmp
        {
            get { return _GeneroEmp; }
            set { _GeneroEmp = value; }
        }

        public string EmailEmp
        {
            get { return _EmailEmp; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("El correo electronico  del Empleado no debe quedar vacío.");
                }
                else if (value.Length > 30)
                {
                    throw new Exception("El correo electronico del Empleado no debe tener mas de 30 caracteres");
                }
                else
                {
                    _EmailEmp = value.ToUpper();
                }
            }
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
