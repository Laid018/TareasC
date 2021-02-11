using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Interfaces
{
    public interface IPresentadorVisualizarTareas
    {
        void BuscarTareasCompletadas();
        void BuscarTareasPendientes();
        void BuscarTareasSinComenzar();
        void CargarTabla();
    }
}
