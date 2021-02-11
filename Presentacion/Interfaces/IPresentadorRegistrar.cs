using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Interfaces
{
    public interface IPresentadorRegistrar
    {
        string nombre { get; set; }
        string apellido { get; set; }
        int dni { get; set; }
        int telefono { get; set; }
        string direccion { get; set; }
        string nick { get; set; }
        string clave { get; set; }
        void RegistrarUsuario();
    }
}
