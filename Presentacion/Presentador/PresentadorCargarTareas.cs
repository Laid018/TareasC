using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentacion.Interfaces;
using Modelo;
using Datos.Entidades;

namespace Presentacion.Presentador
{
    public class PresentadorCargarTareas
    {
        private readonly IPresentadorCargarTareas _vista;
        private Tareas tarea;
        private ETareas _tareas = new ETareas();
        public PresentadorCargarTareas(IPresentadorCargarTareas vista)
        {
            _vista = vista;
        }

        public Tareas ObtenerId(int id)
        {
            return _tareas.ObtenerTareaById(id);
        }

        public void RegistrarTarea()
        {
            if (tarea == null) tarea = new Tareas();
            tarea.Titulo = _vista.titulo;
            tarea.Descripcion = _vista.descripcion;
            tarea.Color = _vista.color;
            tarea.FechaInicio = _vista.fechaInicio;
            tarea.FechaFin = _vista.fechaFin;
            tarea.porcentaje = _vista.porcentaje;
            tarea.IdPersona = _vista.id;

            _tareas.InsertarTarea(tarea);
        }

        public void ActualizarTarea(Tareas tarea)
        {
            if (tarea != null)
            {
                tarea.Id = _vista.idTarea;
                tarea.Titulo = _vista.titulo;
                tarea.Descripcion = _vista.descripcion;
                tarea.Color = _vista.color;
                tarea.FechaInicio = _vista.fechaInicio;
                tarea.FechaFin = _vista.fechaFin;
                tarea.porcentaje = _vista.porcentaje;
                tarea.IdPersona = _vista.id;

                _tareas.ActualizarTarea(tarea);
            }
        }
        
    }
}
