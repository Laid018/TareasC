using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using Presentacion.Interfaces;
using Datos.Entidades;

namespace Presentacion.Presentador
{
    public class presentadorLogin
    {
        private IPresentadorLogin _vista;
        private Eusuario _user = new Eusuario();
        private Usuario usuario;

        public presentadorLogin(IPresentadorLogin vista)
        {
            _vista = vista;
        }

        public bool Acceder()
        {
            try
            {
                if (usuario == null) usuario = new Usuario();
                usuario.nick = _vista.usuario;
                usuario.clave = _vista.clave;
                return _user.Acceder(usuario);
            }
            catch (Exception ex)
            {
                _vista.MostrarMensaje("Error" + ex);
                return false;
            }

        }

        public Usuario ObtenerUsuario()
        {
           return _user.GetUsuario(_vista.usuario, _vista.clave);
        }
    }
}
