using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo;

namespace Datos.Entidades
{
    public class Eusuario
    {
        public bool Acceder(Usuario usuario)
        {
            WSTareas.WSTareas ws = new WSTareas.WSTareas();
            return ws.Acceder(usuario);
        }

        public Usuario GetUsuario(string nick, string clave)
        {
            WSTareas.WSTareas ws = new WSTareas.WSTareas();
            return ws.GetUsuario(nick, clave);        }

        public int ObtenerUltimoId()
        {
            WSTareas.WSTareas ws = new WSTareas.WSTareas();
            return ws.ObtenerUltimoId();
        }
    }
}