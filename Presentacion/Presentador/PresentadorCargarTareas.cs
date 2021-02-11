using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using Entidades;
using Presentacion.Interfaces;

namespace Presentacion.Presentador
{
    public class PresentadorCargarTareas
    {
        private readonly IPresentadorCargarTareas _vista;
        private ETareas tarea;
        private Tareas _tarea = new Tareas();
        public PresentadorCargarTareas(IPresentadorCargarTareas vista)
        {
            _vista = vista;
        }

        public ETareas ObtenerId(int id)
        {
            return _tarea.ObtenerTareaById(id);            
        }

        public void RegistrarTarea()
        {
            if (tarea == null) tarea = new ETareas();
            tarea.titulo = _vista.titulo;
            tarea.descripcion = _vista.descripcion;
            tarea.color = _vista.color;
            tarea.fechaInicio = _vista.fechaInicio;
            tarea.fechaFin = _vista.fechaFin;
            tarea.porcentaje = _vista.porcentaje;
            tarea.idPersona = _vista.id;

            _tarea.InsertarTarea(tarea);
        }

        public void ActualizarTarea(ETareas tarea)
        {
            if (tarea != null)
            {
                tarea.id = _vista.idTarea;
                tarea.titulo = _vista.titulo;
                tarea.descripcion = _vista.descripcion;
                tarea.color = _vista.color;
                tarea.fechaInicio = _vista.fechaInicio;
                tarea.fechaFin = _vista.fechaFin;
                tarea.porcentaje = _vista.porcentaje;
                tarea.idPersona = _vista.id;

                _tarea.ActualizarTarea(tarea);
            }
        }
        
    }
}
