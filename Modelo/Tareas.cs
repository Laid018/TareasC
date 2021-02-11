using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;

namespace Modelo
{
    public class Tareas
    {
        private TareasDao ojb = new TareasDao();
        
        public DataTable MostrarTareas()
        {
            return ojb.MostrarTareas();
        }

        public ETareas ObtenerTareaById(int id)
        {
            return ojb.ObtenerTareaById(id);
        }

        public void InsertarTarea(ETareas tarea)
        {
            try
            {
                ojb.InsertarTarea(tarea);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar tarea "+ex);
            }
        }
        
        public void ActualizarTarea(ETareas tarea)
        {
            try
            {
                ojb.ActualizarTarea(tarea);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar tarea "+ex);
            }
        }

        public void EliminarTarea(int id)
        {
            try
            {
                ojb.EliminarTarea(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al borrar tarea "+ex);
            }
        }

        public List<ETareas> VerTareasProximasVencer(int id)
        {
            return ojb.VerTareasProximasVencer(id);
        }

        public DataSet VerTareasCompletadas(int id)
        {
            return ojb.VerTareasCompletadas(id);
        }

        public DataSet VerTareasPendientes(int id)
        {
            return ojb.VerTareasPendientes(id);
        }

        public DataSet VerTareasSinComenzar(int id)
        {
            return ojb.VerTareasSinComenzar(id);
        }

        public DataSet BuscarTareas(string tarea)
        {
            return ojb.BuscarTareas(tarea); 
        }

        public DataSet BuscarTareasCompletadas(string tarea, int id)
        {
            return ojb.BuscarTareasCompletadas(tarea, id);
        }

        public DataSet BuscarTareasPendientes(string tarea, int id)
        {
            return ojb.BuscarTareasPendientes(tarea, id);
        }

        public DataSet BuscarTareasSinComenzar(string tarea, int id)
        {
            return ojb.BuscarTareasSinComenzar(tarea, id);
        }
    }
}

