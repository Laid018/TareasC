using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Entidades;

namespace Datos
{
    public class PersonaDao:Conexion
    {
        public DataTable MostrarPersonas()
        {
            var tabla = new DataTable();
            using (var con = GetConexion())
            {
                con.Open();
                using (var comand = new SqlCommand())
                {
                    comand.Connection = con;
                    comand.CommandText = "Select * from Persona";
                    comand.CommandType = CommandType.Text;
                    SqlDataReader leer = comand.ExecuteReader();
                    tabla.Load(leer);
                    return tabla;
                }
            }
        }

        public EPersona GetById(int id)
        {
            using (var con = GetConexion())
            {
                con.Open();
                using (var comand = new SqlCommand())
                {
                    comand.Connection = con;
                    comand.CommandText = "Select * from persona where Id = @id";
                    comand.CommandType = CommandType.Text;
                    comand.Parameters.AddWithValue("@id", id);
                    SqlDataReader dr = comand.ExecuteReader();
                    if (dr.Read())
                    {
                        EPersona persona = new EPersona
                        {
                            id = Convert.ToInt32(dr["Id"]),
                            nombre = Convert.ToString(dr["nombre"]),
                            apellido = Convert.ToString(dr["apellido"]),
                            dni = Convert.ToInt32(dr["dni"]),
                            telefono = Convert.ToInt32(dr["telefono"]),
                            idUsuario = Convert.ToInt32(dr["idUsurio"])
                        };
                        return persona;
                    }
                }
            }
            return null;
        }

        public int ObtenerUltimoId()
        {
            using (var con = GetConexion())
            {
                con.Open();
                using (var comand = new SqlCommand())
                {
                    comand.Connection = con;
                    comand.CommandText = "SELECT MAX(Id) as Id FROM persona";
                    comand.CommandType = CommandType.Text;
                    SqlDataReader dr = comand.ExecuteReader();
                    if (dr.Read())
                    {
                        var id = Convert.ToInt32(dr["Id"]);
                        return id;
                    }
                }
            }
            return -1;
        }

        public void InsertarPersona(EPersona persona, EUsuario user)
        {
            // Inserta en tabla usuario los datos correspondientes
            using (var con = GetConexion())
            {
                con.Open();
                using (var comand = new SqlCommand())
                {
                    comand.Connection = con;
                    comand.CommandText = "Insert into usuario (nick, clave) values(@nick, @clave)";
                    comand.CommandType = CommandType.Text;
                    comand.Parameters.AddWithValue("@nick", user.nick);
                    comand.Parameters.AddWithValue("@clave", user.clave);
                    var x = comand.ExecuteNonQuery();
                    comand.Parameters.Clear();

                    if (x > 0)
                    {
                        using (var comand1 = new SqlCommand())
                        {
                            comand1.Connection = con;
                            comand1.CommandText = 
                                            "Insert into Persona (nombre,apellido,dni,telefono,direccion,idUsuario) " +
                                            "values(@nombre,@apellido,@dni,@telefono,@direccion, @idusuario)";
                            comand1.CommandType = CommandType.Text;
                            // Solicitamos el id del ultimo usuario registrado
                            var idUsuario = new UsuarioDao();
                            var id = idUsuario.ObtenerUltimoId();
                            // Cargamos los parametros
                            comand1.Parameters.AddWithValue("@nombre", persona.nombre);
                            comand1.Parameters.AddWithValue("@apellido", persona.apellido);
                            comand1.Parameters.AddWithValue("@dni", persona.dni);
                            comand1.Parameters.AddWithValue("@telefono", persona.telefono);
                            comand1.Parameters.AddWithValue("@direccion", persona.direccion);
                            comand1.Parameters.AddWithValue("@idusuario", id);
                            comand1.ExecuteNonQuery();
                            comand.Parameters.Clear();
                        }
                    }
                }
            }
        }
    }
}
