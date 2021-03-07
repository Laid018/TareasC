using System;
using System.Collections.Generic;
using System.Linq;
using Modelo;
using System.Data.Entity.SqlServer;
using Datos;

namespace Datos.Entidades
{
    public class ETareas
    {
        //***************************** METODOS WEB SERVICE ***********************************///
        // LISTAR TAREAS
        public List<Tareas> MostrarTareas()
        {
            WSTareas.WSTareas ws = new WSTareas.WSTareas();
            return ws.MostrarTareas();
        }
        // OBTENER TAREA POR SU ID
        public Tareas ObtenerTareaById(int id)
        {
            WSTareas.WSTareas ws = new WSTareas.WSTareas();
            return ws.ObtenerTareaById(id);
        }
        // INSERTAR TAREA
        public void InsertarTarea(Tareas oTareas)
        {
            WSTareas.WSTareas ws = new WSTareas.WSTareas();
            ws.InsertarTarea(oTareas);
        }
        // ACTUALIZAR TAREA
        public void ActualizarTarea(Tareas oTareas)
        {
            WSTareas.WSTareas ws = new WSTareas.WSTareas();
            ws.ActualizarTarea(oTareas);
        }
        // ELIMINAR TAREA
        public void EliminarTarea(int id)
        {
            WSTareas.WSTareas ws = new WSTareas.WSTareas();
            ws.EliminarTarea(id);
        }

        // MOSTRAR TAREAS PROXIMAS A VENCER
        public List<Tareas> MostrarTareasProximasVencer(int id)
        {
            WSTareas.WSTareas ws = new WSTareas.WSTareas();
            return ws.MostrarTareasProximasVencer(id);
        }

        // Tareas que esten a 15 min de comenzar
        public bool TareasProximasComenzar(int id)
        {
            WSTareas.WSTareas ws = new WSTareas.WSTareas();
            return ws.TareasProximasComenzar(id);
        }

            // BUSCAR TAREA
            public List<Tareas> BuscarTareas(string titulo)
        {
            WSTareas.WSTareas ws = new WSTareas.WSTareas();
            return ws.BuscarTareas(titulo);
        }

        // BUSCAR TAREA COMPLETADAS
        public List<Tareas> BuscarTareasCompletadas(string titulo, int id)
        {
            WSTareas.WSTareas ws = new WSTareas.WSTareas();
            return ws.BuscarTareasCompletadas(titulo,id);
        }
        // MOSTRAR TAREAS COMPLETADAS
        public List<Tareas> MostrarTareasCompletadas(int id)
        {
            WSTareas.WSTareas ws = new WSTareas.WSTareas();
            return ws.MostrarTareasCompletadas(id);
        }
        // BUSCAR TAREAS PENDIENTES
        public List<Tareas> BuscarTareasPendientes(string titulo, int id)
        {
            WSTareas.WSTareas ws = new WSTareas.WSTareas();
            return ws.BuscarTareasPendientes(titulo, id);
        }
        // MOSTRAR TAREAS PENDIENTES
        public List<Tareas> MostrarTareasPendientes(int id)
        {
            WSTareas.WSTareas ws = new WSTareas.WSTareas();
            return ws.MostrarTareasPendientes(id);
        }
        // BUSCAR TAREAS SIN COMENZAR
        public List<Tareas> BuscarTareasSinComenzar(string titulo, int id)
        {
            WSTareas.WSTareas ws = new WSTareas.WSTareas();
            return ws.BuscarTareasSinComenzar(titulo, id);
        }
        // MOSTRAR TAREAS SIN COMENZAR
        public List<Tareas> MostrarTareasSinComenzar(int id)
        {
            WSTareas.WSTareas ws = new WSTareas.WSTareas();
            return ws.MostrarTareasSinComenzar(id);
        }

    }
}