using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentacion.Interfaces;
using Modelo;
using Datos.Entidades;
using System.Data;

namespace Presentacion.Presentador
{
    public class PresentadorVisualizarTareas
    {
        private readonly IPresentadorVisualizarTareas _vista;
        private Tareas tareas;
        private ETareas _tareas = new ETareas();

        public PresentadorVisualizarTareas(IPresentadorVisualizarTareas vista)
        {
            _vista = vista;
        }

        public List<Tareas> CargarTabla()
        {
            return _tareas.MostrarTareas();
        }

        public List<Tareas> BuscarTareasCompletadas(string tarea, int id)
        {
            return _tareas.BuscarTareasCompletadas(tarea, id);
        }

        public List<Tareas> BuscarTareasPendientes(string tarea, int id)
        {
            return _tareas.BuscarTareasPendientes(tarea, id);
        }

        public List<Tareas> BuscarTareasSinComenzar(string tarea, int id)
        {
            return _tareas.BuscarTareasSinComenzar(tarea, id);
        }

        public List<Tareas> MostrarTareasCompletadas(int id)
        {
            return _tareas.MostrarTareasCompletadas(id);
        }

        public List<Tareas> MostrarTareasPendientes(int id)
        {
            return _tareas.MostrarTareasPendientes(id);
        }

        public List<Tareas> MostrarTareasSinComenzar(int id)
        {
            return _tareas.MostrarTareasSinComenzar(id);
        }
    }
}
