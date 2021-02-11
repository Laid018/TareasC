using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;

namespace Modelo
{
    public class Persona
    {
        private PersonaDao _persona = new PersonaDao();
        private readonly StringBuilder stringBuilder = new StringBuilder();

        public int ObtenerUltimoId()
        {return _persona.ObtenerUltimoId();}

        public void RegistrarUsuario(EPersona persona, EUsuario user)
        {
            if (ValidarPersona(persona, user))
            {
                if (_persona.GetById(persona.id) == null)
                     _persona.InsertarPersona(persona, user);
                else
                {
                    //UPDATE
                }
            }
        }

        private bool ValidarPersona(EPersona persona, EUsuario user)
        {
            stringBuilder.Clear();

            if (string.IsNullOrEmpty(persona.nombre)) stringBuilder.Append("El campo nombre es obligatorio");
            if (string.IsNullOrEmpty(persona.apellido)) stringBuilder.Append(Environment.NewLine + "El campo apellido es obligatorio");
            if (persona.dni <= 0) stringBuilder.Append(Environment.NewLine + "El campo dni es obligatorio");
            if (persona.telefono <= 0) stringBuilder.Append(Environment.NewLine + "El campo teléfono es obligatorio");
            if (string.IsNullOrEmpty(persona.direccion)) stringBuilder.Append(Environment.NewLine + "El campo dirección es obligatorio");
            if (string.IsNullOrEmpty(user.nick)) stringBuilder.Append(Environment.NewLine + "El campo nick es obligatorio");
            if (string.IsNullOrEmpty(user.clave)) stringBuilder.Append(Environment.NewLine + "El campo clave es obligatorio");

            return stringBuilder.Length == 0;
        }
    }
}
