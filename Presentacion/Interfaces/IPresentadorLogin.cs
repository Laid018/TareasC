using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Interfaces
{
    public interface IPresentadorLogin
    {
        string usuario { get; set; }
        string clave { get; set; }

        void Acceder();
        void MostrarMensaje(string mje);

    }
}
