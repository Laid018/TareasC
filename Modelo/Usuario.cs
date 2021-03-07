using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Usuario
    {   
        public int Id { get; set; }
        public string nick { get; set; }
        public string clave { get; set; }

        public virtual List<Persona> persona { get; set; }

    }
}
