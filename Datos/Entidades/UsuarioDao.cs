using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Datos
{
    public class UsuarioDao:Conexion
    {
        public DataTable MostrarUsuarios()
        {
            var tabla = new DataTable();
            using (var con = GetConexion())
            {
                con.Open();
                using (var comand = new SqlCommand())
                {
                    comand.Connection = con;
                    comand.CommandText = "Select * from usuario";
                    comand.CommandType = CommandType.Text;
                    SqlDataReader leer = comand.ExecuteReader();
                    tabla.Load(leer);
                    return tabla;
                }
            }
        }

        public EUsuario ObtenerUsuario(string nick, string clave)
        {
            using (var con = GetConexion())
            {
                con.Open();
                using (var comand = new SqlCommand())
                {
                    comand.Connection = con;
                    comand.CommandText = "select * from usuario where nick='" + nick + "' and clave='" + clave + "';";
                    comand.CommandType = CommandType.Text;
                    SqlDataReader dr = comand.ExecuteReader();
                    if (dr.Read())
                    {
                        EUsuario usuario = new EUsuario
                        {
                            id = Convert.ToInt32(dr["Id"]),
                            nick = Convert.ToString(dr["nick"]),
                            clave = Convert.ToString(dr["clave"])
                        };
                        return usuario;
                    }
                }
                return null;
            }
        }

        public int ObtenerUltimoId()
        {
            using (var con = GetConexion())
            {
                con.Open();
                using (var comand = new SqlCommand())
                {
                    comand.Connection = con;
                    comand.CommandText = "SELECT MAX(Id) as Id FROM usuario";
                    comand.CommandType = CommandType.Text;
                    SqlDataReader dr = comand.ExecuteReader();
                    if (dr.Read())
                    {
                        var id = Convert.ToInt32(dr["Id"]);
                        return id;
                    }
                }
            }

            return 0;
        }

        public void InsertarUsuario(string nick, string clave)
        {
            using (var con = GetConexion())
            {
                con.Open();
                using (var comand = new SqlCommand())
                {
                    comand.Connection = con;
                    comand.CommandText = "Insert into usuario values('" + nick + "','" + clave + "')";
                    comand.CommandType = CommandType.Text;
                    comand.ExecuteNonQuery();
                }
            }
        }

        public bool Acceder(EUsuario user)
        {
            try
            {
                using (var con = GetConexion())
                {
                    con.Open();
                    using (var comand = new SqlCommand())
                    {
                        comand.Connection = con;
                        comand.CommandText = "select * from usuario where nick='" + user.nick + "' and clave='" + user.clave + "';";
                        comand.CommandType = CommandType.Text;
                        SqlDataReader dr = comand.ExecuteReader();
                        if (dr.HasRows)
                            return true;
                        else
                            return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("el error es"+ex);
                return false;
            }
        }
    }
}
