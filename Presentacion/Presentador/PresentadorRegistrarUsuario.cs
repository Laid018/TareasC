using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Modelo;
using Presentacion.Interfaces;

namespace Presentacion.Presentador
{
    public class PresentadorRegistrarUsuario
    {
        private readonly IPresentadorRegistrar _vista;
        private EPersona persona;
        private EUsuario usuario;
        private Persona _persona = new Persona();
        public PresentadorRegistrarUsuario(IPresentadorRegistrar vista)
        {
            _vista = vista;
        }
        public void RegistrarUsuario()
        {
            try
            {
                if (persona == null) persona = new EPersona();
                if (usuario == null) usuario = new EUsuario();
                // Sus datos de acceso
                usuario.nick = _vista.nick;
                usuario.clave = _vista.clave;
                // Datos de la persona
                persona.nombre = _vista.nombre;
                persona.apellido = _vista.apellido;
                persona.dni = _vista.dni;
                persona.telefono = _vista.telefono;
                persona.direccion = _vista.direccion;
                // Llamamos al metodo para registrar pesona con su usuario de acceso.
                _persona.RegistrarUsuario(persona, usuario);
            }
            catch (Exception ex)
            { Console.WriteLine("Error al ingreser persona"+ex);}
        }
    }
}
