using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
//Espacio de nombres para la configuracion (web.config)
using System.Configuration;

namespace MVCREAL.Models
{
    public class HelperDepartamento
    {
        SqlConnection con;
        SqlCommand com;
        SqlDataReader reader;
        public HelperDepartamento()
        {
            String cadena = ConfigurationManager.ConnectionStrings["cadenaHospital"].ConnectionString;
            this.con = new SqlConnection(cadena);
            this.com = new SqlCommand();
            this.com.Connection = this.con;
        }
        public Departamento BuscarDepartamento(int deptno)
        {
            Departamento departamento = null;
            String sql = "SELECT * FROM DEPT WHERE DEPT_NO = @DEPTNO";
            SqlParameter parameter = new SqlParameter("@DEPTNO", deptno);
            this.com.Parameters.Add(parameter);
            this.com.CommandType = System.Data.CommandType.Text;
            this.com.CommandText = sql;
            this.con.Open();
            this.reader = this.com.ExecuteReader();
            if (this.reader.HasRows)
            {
                departamento = new Departamento();
                this.reader.Read();
                departamento.Numero = int.Parse(this.reader["DEPT_NO"].ToString());
                departamento.Nombre = this.reader["DNOMBRE"].ToString();
                departamento.Localidad = this.reader["LOC"].ToString();

            }
            this.reader.Close();
            this.com.Parameters.Clear();
            this.con.Close();
            return departamento;
        }
    }
}