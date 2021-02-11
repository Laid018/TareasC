using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;
using Datos.WSTareas;

namespace Datos
{
    public class TareasDao:Conexion
    {
        public DataTable MostrarTareas()
        {
            DataTable tabla = new DataTable();
            using (var con = GetConexion())
            {
                con.Open();
                using (var comand = new SqlCommand())
                {
                    comand.Connection = con;
                    comand.CommandText = "Select * from tareas";
                    comand.CommandType = CommandType.Text;
                    SqlDataReader dr = comand.ExecuteReader();
                    tabla.Load(dr);
                    return tabla;
                }
            }
        }

#region Metods de Web Service
        // Metodo de web service  
        public DataSet BuscarTareas(string tarea)
        {
            WSTareas.WSTareasSoapClient ws = new WSTareas.WSTareasSoapClient();
            return ws.BuscarTareas(tarea);
        }
        
        public DataSet BuscarTareasCompletadas(string tarea, int id)
        {
            WSTareas.WSTareasSoapClient ws = new WSTareas.WSTareasSoapClient();
            return ws.BuscarTareasCompletadas(tarea, id);
        }

        public DataSet BuscarTareasPendientes(string tarea, int id)
        {
            WSTareas.WSTareasSoapClient ws = new WSTareas.WSTareasSoapClient();
            return ws.BuscarTareasPendientes(tarea, id);
        }

        public DataSet BuscarTareasSinComenzar(string tarea, int id)
        {
            WSTareas.WSTareasSoapClient ws = new WSTareas.WSTareasSoapClient();
            return ws.BuscarTareasSinComenzar(tarea, id);
        }

        public DataSet VerTareasCompletadas(int id)
        {
            WSTareas.WSTareasSoapClient ws = new WSTareas.WSTareasSoapClient();
            return ws.MostrarTareasCompletadas(id);
        }

        public DataSet VerTareasPendientes(int id)
        {
            WSTareas.WSTareasSoapClient ws = new WSTareas.WSTareasSoapClient();
            return ws.MostrarTareasPendientes(id);
        }

        public DataSet VerTareasSinComenzar(int id)
        {
            WSTareas.WSTareasSoapClient ws = new WSTareas.WSTareasSoapClient();
            return ws.MostrarTareasSinComenzar(id);
        }

        public List<ETareas> VerTareasProximasVencer(int id)
        {
             List<ETareas> _list = new List<ETareas>();
            using (var con = GetConexion())
            {
                con.Open();
                using (var comand = new SqlCommand())
                {
                   comand.Connection = con;
                   comand.CommandText = "select * , DATEDiFF(day,FechaFin, GETDATE()) as fechaVencimiento from Tareas where IdPersona = @id";
                   comand.CommandType = CommandType.Text;
                   comand.Parameters.AddWithValue("@id", id);
                   SqlDataReader dr = comand.ExecuteReader();
                   while (dr.Read())
                   {
                       if ((Convert.ToInt32(dr["fechaVencimiento"]) < 5) && (Convert.ToInt32(dr["fechaVencimiento"]) > 0))
                       {
                            ETareas tarea = new ETareas();
                            tarea.id = Convert.ToInt32(dr["Id"]);
                            tarea.titulo = Convert.ToString(dr["Titulo"]);
                            tarea.descripcion = Convert.ToString(dr["Descripcion"]);
                            tarea.color = Convert.ToString(dr["Color"]);
                            tarea.fechaInicio = Convert.ToDateTime(dr["FechaInicio"]);
                            tarea.fechaFin = Convert.ToDateTime(dr["FechaFin"]);
                            tarea.porcentaje = Convert.ToInt32(dr["porcentaje"]);
                            _list.Add(tarea);
                       }
                        else
                        {
                            _list.Clear();
                          return _list;
                        }
                   }
                   return _list;
                }
            }
        }
#endregion

        public ETareas ObtenerTareaById(int id)
        {
            using (var con = GetConexion())
            {
                con.Open();
                using (var comand = new SqlCommand())
                {
                    comand.Connection = con;
                    comand.CommandText = "select * from tareas where Id = @id";
                    comand.CommandType = CommandType.Text;
                    comand.Parameters.AddWithValue("@id", id);
                    SqlDataReader dr = comand.ExecuteReader();
                    if (dr.Read())
                    {
                        ETareas tarea = new ETareas
                        {
                            id = Convert.ToInt32(dr["Id"]),
                            titulo = Convert.ToString(dr["Titulo"]),
                            descripcion = Convert.ToString(dr["Descripcion"]),
                            color = Convert.ToString(dr["Color"]),
                            fechaInicio = Convert.ToDateTime(dr["FechaInicio"]),
                            fechaFin = Convert.ToDateTime(dr["FechaFin"]),
                            idPersona = Convert.ToInt32(dr["IdPersona"]),
                            porcentaje = Convert.ToInt32(dr["porcentaje"]),
                        };
                        return tarea;
                    }
                }
                return null;
            }
        }
        
        public void InsertarTarea(ETareas tarea)
        {
            using (var con = GetConexion())
            {
                con.Open();
                using (var comand = new SqlCommand())
                {
                    comand.Connection = con;
                    comand.CommandText = 
                        "Insert into tareas (Titulo, Descripcion, Color, FechaInicio, FechaFin, IdPersona, porcentaje) " +
                        "values(@titulo,@descripcion,@color,@fechaInicio,@fechaFin,@idPersona,@porcentaje)";
                    comand.CommandType = CommandType.Text;
                    comand.Parameters.AddWithValue("@titulo", tarea.titulo);
                    comand.Parameters.AddWithValue("@descripcion", tarea.descripcion);
                    comand.Parameters.AddWithValue("color", tarea.color);
                    comand.Parameters.AddWithValue("@fechaInicio", tarea.fechaInicio);
                    comand.Parameters.AddWithValue("@fechaFin", tarea.fechaFin);
                    comand.Parameters.AddWithValue("@idPersona", tarea.idPersona);
                    comand.Parameters.AddWithValue("@porcentaje", tarea.porcentaje);

                    comand.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarTarea(ETareas tarea)
        {
            using(var con = GetConexion())
            {
                con.Open();
                using (var comand = new SqlCommand())
                {
                    comand.Connection = con;
                    comand.CommandText = "Update tareas set Titulo=@titulo,Descripcion=@descripcion,Color=@color,"
                        +"FechaInicio=@fechaInicio,FechaFin=@fechaFin,porcentaje=@porcentaje where Id=@id";
                    comand.CommandType = CommandType.Text;
                    comand.Parameters.AddWithValue("@titulo", tarea.titulo);
                    comand.Parameters.AddWithValue("@descripcion", tarea.descripcion);
                    comand.Parameters.AddWithValue("@color", tarea.color);
                    comand.Parameters.AddWithValue("@fechaInicio", tarea.fechaInicio);
                    comand.Parameters.AddWithValue("@fechaFin", tarea.fechaFin);
                    comand.Parameters.AddWithValue("@id", tarea.id);
                    comand.Parameters.AddWithValue("@porcentaje", tarea.porcentaje);

                    comand.ExecuteNonQuery();
                }
            }
        }

        public void EliminarTarea(int id)
        {
            using (var con = GetConexion())
            {
                con.Open();
                using (var comand = new SqlCommand())
                {
                    comand.Connection = con;
                    comand.CommandText = "Delete from tareas where Id = @id";
                    comand.CommandType = CommandType.Text;
                    comand.Parameters.AddWithValue("@id", id);

                    comand.ExecuteNonQuery();
                }
            }
        }
    }
}
