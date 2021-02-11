using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Datos
{
    public abstract class Conexion
    {

        private readonly string con;

        public Conexion()
        {
            //con = "Data Source=DESKTOP-QTDUMVH\\SQLEXPRESS;Initial Catalog=Tarea;Integrated Security=True";
            con = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        }
        public SqlConnection GetConexion()
        {
            return new SqlConnection(con);
        }
    }
}
