using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSTareas.Modelo
{
    public class Tareas
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Color { get; set; }
        public System.DateTime FechaInicio { get; set; }
        public System.DateTime FechaFin { get; set; }
        public int? IdPersona { get; set; }
        public int? porcentaje { get; set; }

    }
}