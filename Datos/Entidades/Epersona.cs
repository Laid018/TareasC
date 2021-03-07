using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo;

namespace Datos.Entidades
{
    public class Epersona
    {
        public void RegistrarUsuario(Persona p, Usuario u)
        {
            WSTareas.WSTareas ws = new WSTareas.WSTareas();
            ws.RegistrarUsuario(p, u);
        }
    }
}