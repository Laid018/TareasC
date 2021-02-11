using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WSTareas
{
    /// <summary>
    /// Descripción breve de WSTareas
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WSTareas : System.Web.Services.WebService
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-QTDUMVH\\SQLEXPRESS;Initial Catalog=Tarea;Integrated Security=True");

        [WebMethod]
        public DataSet ListarTareas()
        {
            DataSet ds = new DataSet(); 
            con.Open();
            using (var comand = new SqlCommand())
            {
               comand.Connection = con;
               comand.CommandText = "select * from tareas";
               comand.CommandType = CommandType.Text;
               SqlDataAdapter da = new SqlDataAdapter(comand); 
               da.Fill(ds); 
               con.Close();
               return ds;
            }
        }

        [WebMethod]
        public DataSet BuscarTareas(string titulo)
        {
            DataSet ds = new DataSet(); 
            con.Open();
            using (var comand = new SqlCommand())
            {
                comand.Connection = con;
                comand.CommandText = "Select * from tareas where Titulo LIKE @titulo +'%'";
                /* comand.CommandText = "Select * from Tareas where Titulo LIKE '"+ titulo.Trim() +"%'"; */
                comand.CommandType = CommandType.Text;
                comand.Parameters.AddWithValue("@titulo", titulo.Trim());
               SqlDataAdapter da = new SqlDataAdapter(comand); 
               da.Fill(ds); 
               con.Close();
               return ds;
            }
        }

        [WebMethod]
        public DataSet BuscarTareasCompletadas(string titulo, int id)
        {
            DataSet ds = new DataSet(); 
            con.Open();
            using (var comand = new SqlCommand())
            {
                comand.Connection = con;
                comand.CommandText = "Select * from tareas where Titulo LIKE @titulo +'%' and porcentaje=100 and IdPersona=@id";
                /* comand.CommandText = "Select * from Tareas where Titulo LIKE '"+ titulo.Trim() +"%'"; */
                comand.CommandType = CommandType.Text;
                comand.Parameters.AddWithValue("@titulo", titulo.Trim());
                comand.Parameters.AddWithValue("@id", id);
               SqlDataAdapter da = new SqlDataAdapter(comand); 
               da.Fill(ds); 
               con.Close();
               return ds;
            }
        }

        [WebMethod]
        public DataSet BuscarTareasPendientes(string titulo, int id)
        {
            DataSet ds = new DataSet(); 
            con.Open();
            using (var comand = new SqlCommand())
            {
                comand.Connection = con;
                comand.CommandText = "Select * from tareas where Titulo LIKE @titulo +'%' and porcentaje < 100 and IdPersona=@id";
                /* comand.CommandText = "Select * from Tareas where Titulo LIKE '"+ titulo.Trim() +"%'"; */
                comand.CommandType = CommandType.Text;
                comand.Parameters.AddWithValue("@titulo", titulo.Trim());
                comand.Parameters.AddWithValue("@id", id);
               SqlDataAdapter da = new SqlDataAdapter(comand); 
               da.Fill(ds); 
               con.Close();
               return ds;
            }
        }
        
        [WebMethod]
        public DataSet BuscarTareasSinComenzar(string titulo, int id)
        {
            DataSet ds = new DataSet(); 
            con.Open();
            using (var comand = new SqlCommand())
            {
                comand.Connection = con;
                comand.CommandText = "Select * from tareas where Titulo LIKE @titulo +'%' and porcentaje=0 and IdPersona=@id";
                /* comand.CommandText = "Select * from Tareas where Titulo LIKE '"+ titulo.Trim() +"%'"; */
                comand.CommandType = CommandType.Text;
                comand.Parameters.AddWithValue("@titulo", titulo.Trim());
                comand.Parameters.AddWithValue("@id", id);
               SqlDataAdapter da = new SqlDataAdapter(comand); 
               da.Fill(ds); 
               con.Close();
               return ds;
            }
        }

        [WebMethod]
        public DataSet MostrarTareasCompletadas(int id)
        {
            DataSet ds = new DataSet();
            con.Open();
            using (var comand = new SqlCommand())
            {
                comand.Connection = con;
                comand.CommandText = "select * from Tareas where porcentaje=100 and IdPersona=@id";
                comand.CommandType = CommandType.Text;
                comand.Parameters.AddWithValue("@id", id);    
                SqlDataAdapter da = new SqlDataAdapter(comand);
                da.Fill(ds);
                con.Close();
                if ((Convert.ToInt32(ds.Tables[0].Rows[0]["porcentaje"])) == 100)
                {
                   return ds;
                }
                else
                {
                    return null;
                }
            }
        }

        [WebMethod]
        public DataSet MostrarTareasPendientes(int id)
        {
            DataSet ds = new DataSet();
            con.Open();
            using (var comand = new SqlCommand())
            {
               comand.Connection = con;
               comand.CommandText = "select * from Tareas where porcentaje < 100 and IdPersona=@id";
               comand.CommandType = CommandType.Text;
               comand.Parameters.AddWithValue("@id", id);    
               SqlDataAdapter da = new SqlDataAdapter(comand);
               da.Fill(ds);
               con.Close();
                if ((Convert.ToInt32(ds.Tables[0].Rows[0]["porcentaje"])) > 100)
               {
                   return null;
               }
                else
                {
                   return ds;
                }
            }
        }

        [WebMethod]
        public DataSet MostrarTareasSinComenzar(int id)
        {
           DataSet ds = new DataSet();
            con.Open();
            using (var comand = new SqlCommand())
            {
               comand.Connection = con;
               comand.CommandText = "select * from Tareas where porcentaje=0 and IdPersona=@id";
               comand.CommandType = CommandType.Text;
               comand.Parameters.AddWithValue("@id", id);     
               SqlDataAdapter da = new SqlDataAdapter(comand);
               da.Fill(ds);
               con.Close();
               try
               {
                   if ((Convert.ToInt32(ds.Tables[0].Rows[0]["porcentaje"])) > 0)
                   {
                       return null;
                   }
                    else
                    {
                        return ds;
                    }
               }
               catch (Exception e)
               {
                   Console.WriteLine("No hay tareas sin comenzar"+e);
                   return null;
               }
            }
        }
    }
}
