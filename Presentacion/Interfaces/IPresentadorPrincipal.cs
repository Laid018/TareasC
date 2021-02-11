using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Interfaces
{
    public interface IPresentadorPrincipal
    {
        DataTable CargarTareas();
        void TareasAVencer();
    }
}
