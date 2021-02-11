using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentacion.Interfaces;
using Entidades;
using Modelo;
using System.Data;

namespace Presentacion.Presentador
{
    public class PresentadorPrincipal
    {
        private readonly IPresentadorPrincipal _vista;
        private ETareas tarea;
        private Tareas _tarea = new Tareas();

        public PresentadorPrincipal(IPresentadorPrincipal vista)
        {
            _vista = vista;
        }

        public DataTable CargarTareas()
        {
            return _tarea.MostrarTareas();
        }

        public void EliminarTarea(int id)
        {
            _tarea.EliminarTarea(id);
        }

        public List<ETareas> MostrarTareasProximasVencer(int id)
        {
            return _tarea.VerTareasProximasVencer(id);            
        }

        public DataSet MostrarTareasCompletadas(int id)
        {
            return _tarea.VerTareasCompletadas(id);
        }

        public DataSet MostrarTareasPendientes(int id)
        {
            return _tarea.VerTareasPendientes(id);
        }

        public DataSet MostrarTareasSinComenzar(int id)
        {
            return _tarea.VerTareasSinComenzar(id);
        }

        public DataSet BuscarTareas(string tarea)
        {
            return _tarea.BuscarTareas(tarea); 
        }
    }
}
