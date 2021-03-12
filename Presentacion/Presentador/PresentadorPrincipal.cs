using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentacion.Interfaces;
using Datos.Entidades;
using Modelo;

namespace Presentacion.Presentador
{
    public class PresentadorPrincipal
    {
        private readonly IPresentadorPrincipal _vista;
        private ETareas _tarea = new ETareas();
        private Tareas tarea;

        public PresentadorPrincipal(IPresentadorPrincipal vista)
        {
            _vista = vista;
        }

        public List<Tareas> CargarTareas()
        {
            return _tarea.MostrarTareas();
        }

        public void EliminarTarea(int id)
        {
            _tarea.EliminarTarea(id);
        }

        public List<Tareas> MostrarTareasProximasVencer(int id)
        {
            return _tarea.MostrarTareasProximasVencer(id);            
        }

        public List<Tareas> MostrarTareasProximasComenzar(int id)
        {
            return _tarea.MostrarTareasProximasComenzar(id);
        }

        public bool TareasProximasComenzar(int id)
        {
            return _tarea.TareasProximasComenzar(id);
        }

        public List<Tareas> MostrarTareasCompletadas(int id)
        {
            return _tarea.MostrarTareasCompletadas(id);
        }

        public List<Tareas> MostrarTareasPendientes(int id)
        {
            return _tarea.MostrarTareasPendientes(id);
        }

        public List<Tareas> MostrarTareasSinComenzar(int id)
        {
            return _tarea.MostrarTareasSinComenzar(id);
        }

        public List<Tareas> BuscarTareas(string tarea)
        {
            return _tarea.BuscarTareas(tarea); 
        }
    }
}
