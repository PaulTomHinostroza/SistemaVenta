using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class clsCargo
    {
        private int _IdCargo;
        private string _NombreCar;
        private string _DescripcionCar;

        public clsCargo(string parNombreCargo)
        {
            NombreCar = parNombreCargo;
        }
        public clsCargo(int parIdCargo, string parNombreCargo)
        {
            IdCargo = parIdCargo;
            NombreCar = parNombreCargo;
        }

        public int IdCargo
        {
            get { return _IdCargo; }
            set { _IdCargo = value; }
        }

        public string NombreCar
        {
            get { return _NombreCar; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("El nombre del cargo no debe quedar vacío.");
                }
                else if (value.Length > 30)
                {
                    throw new Exception("El nombre del Cargo no puede exceder mas de  30 caracteres");
                }
                else
                {
                    _NombreCar = value.ToUpper();
                }
            }
        }

        public string DescripcionCar
        {
            get { return _DescripcionCar; }
            set
            {
                if (value.Length > 40)
                {
                    throw new Exception("La descripccion del cargo no debe exceder mas de 40 caracteres");
                }
                else
                {
                    _DescripcionCar = value.ToUpper();
                }
            }
        }

        public void InsertarCargo()
        {
            SqlConnection conexion = new SqlConnection("Server=.;Database=CentroComercial;USER=sa;PWD=continental");
            SqlCommand cmd = new SqlCommand("usp_Cargo_Insertar", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@parNombre_Car", NombreCar);
            if (string.IsNullOrEmpty(DescripcionCar))
            {
                cmd.Parameters.AddWithValue("@parDescripccion_Car", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@parDescripccion_Car", DescripcionCar);
            }
            conexion.Open();
            cmd.ExecuteReader();
            conexion.Close();
        }
        public static List<clsCargo> Listar()
        {
            List<clsCargo> x = new List<clsCargo>();
            SqlConnection conexion = new SqlConnection("Server=.;Database=CentroComercial;USER=sa;PWD=continental");
            SqlCommand cmd = new SqlCommand("usp_Cargo_Listar_Todos", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            conexion.Open();
            SqlDataReader contenedor;
            contenedor = cmd.ExecuteReader();

            while (contenedor.Read()==true)
            {
                clsCargo MiObjeto;
                MiObjeto = new clsCargo(Convert.ToInt32(contenedor["IdCargo"]), contenedor["Nombre_Car"].ToString());

                if (contenedor["Descripccion_Car"] != DBNull.Value)
                {
                    MiObjeto.DescripcionCar = contenedor["Descripccion_Car"].ToString();
                }

                x.Add(MiObjeto);
            }
            conexion.Close();
            return x;
        }

    }
}
