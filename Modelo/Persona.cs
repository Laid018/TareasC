using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Persona
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int dni { get; set; }
        public Nullable<int> telefono { get; set; }
        public string direccion { get; set; }
        public Nullable<int> IdUsuario { get; set; }

        public virtual List<Tareas> tareas { get; set; }
        public virtual Usuario usuario { get; set; }

    }
}
