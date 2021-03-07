using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSTareas.Modelo
{
    public class Persona
    {

        public int Id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int dni { get; set; }
        public int? telefono { get; set; }
        public string direccion { get; set; }
        public int? IdUsuario { get; set; }
    }
}