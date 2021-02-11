using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;

namespace Modelo
{
    public class Usuario
    {
        private UsuarioDao obj = new UsuarioDao();

        public readonly StringBuilder stringBuilder = new StringBuilder();

        public int ObtenerUltimoId()
        {
            return obj.ObtenerUltimoId();
        }

        public EUsuario GetUsuario(string nick, string clave)
        {
            return obj.ObtenerUsuario(nick, clave);
        }
        public bool Acceder(EUsuario user)
        {
            try
            {
                return obj.Acceder(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error", ex);
                return false;
            }
        }
    }
}
