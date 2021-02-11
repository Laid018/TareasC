using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Interfaces
{
    public interface IPresentadorCargarTareas
    {
         int idTarea { get; set; }
         int id { get; set; }
         int porcentaje { get; set; }
         string titulo { get; set; }
         string descripcion { get; set; }
         string color { get; set; }
         DateTime fechaInicio { get; set; }
         DateTime fechaFin { get; set; }

        void RegistrarTarea();
        void MostrarMensaje(string mje);
    }
}
