using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentacion.Interfaces;
using Modelo;
using Entidades;
using System.Data;

namespace Presentacion.Presentador
{
    public class PresentadorVisualizarTareas
    {
        private readonly IPresentadorVisualizarTareas _vista;
        private ETareas tareas;
        private Tareas _tareas = new Tareas();

        public PresentadorVisualizarTareas(IPresentadorVisualizarTareas vista)
        {
            _vista = vista;
        }

        public DataTable CargarTabla()
        {
            return _tareas.MostrarTareas();
        }

        public DataSet BuscarTareasCompletadas(string tarea, int id)
        {
            return _tareas.BuscarTareasCompletadas(tarea, id);
        }

        public DataSet BuscarTareasPendientes(string tarea, int id)
        {
            return _tareas.BuscarTareasPendientes(tarea, id);
        }

        public DataSet BuscarTareasSinComenzar(string tarea, int id)
        {
            return _tareas.BuscarTareasSinComenzar(tarea, id);
        }

        public DataSet MostrarTareasCompletadas(int id)
        {
            return _tareas.VerTareasCompletadas(id);
        }

        public DataSet MostrarTareasPendientes(int id)
        {
            return _tareas.VerTareasPendientes(id);
        }

        public DataSet MostrarTareasSinComenzar(int id)
        {
            return _tareas.VerTareasSinComenzar(id);
        }
    }
}
