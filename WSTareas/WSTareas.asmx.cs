using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web.Services;
using WSTareas.Datos;

namespace WSTareas
{
    /// <summary>
    /// Descripción breve de WSTareas
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WSTareas : System.Web.Services.WebService
    {

        //***************************** METODOS WEB SERVICE ********************************
        // MOSTRAR TAREAS
        [WebMethod]
        public List<Tareas> MostrarTareas()
        {
            using (var db = new TareaEntities1())
            {
                var list = db.tareas.Select(t => new Tareas {
                    Id = t.Id,
                    Titulo = t.Titulo,
                    Descripcion = t.Descripcion,
                    Color = t.Color,
                    FechaInicio = t.FechaInicio,
                    FechaFin = t.FechaFin,
                    IdPersona = t.IdPersona,
                    porcentaje = t.porcentaje
                }).ToList();

                return list;
            }
        }

        // OBTENER TAREA POR SU ID
        public Tareas ObtenerTareaById(int id)
        {
            using (var db = new TareaEntities1())
            {
                var tareas = db.tareas.Where(t => t.Id == id)
                                    .Select(t => new Tareas
                                    {
                                        Id = t.Id,
                                        Titulo = t.Titulo,
                                        Descripcion = t.Descripcion,
                                        Color = t.Color,
                                        FechaInicio = t.FechaInicio,
                                        FechaFin = t.FechaFin,
                                        IdPersona = t.IdPersona,
                                        porcentaje = t.porcentaje
                                    });
                if (tareas.Count() > 0)
                {
                    foreach (var tarea in tareas)
                    {
                        Tareas t = new Tareas();
                        t.Id = tarea.Id;
                        t.Titulo = tarea.Titulo;
                        t.Descripcion = tarea.Descripcion;
                        t.Color = tarea.Color;
                        t.FechaInicio = tarea.FechaInicio;
                        t.FechaFin = tarea.FechaFin;
                        t.IdPersona = tarea.IdPersona;
                        t.porcentaje = tarea.porcentaje;

                        return t;
                    }
                }
                else { return null; }
            }
            return null;
        }

        // INSERTAR TAREA
        public void InsertarTarea(Tareas oTareas)
        {
            using (var db = new TareaEntities1())
            {
                tareas tarea = new tareas();
                //tarea.Id = oTareas.Id;
                tarea.Titulo = oTareas.Titulo;
                tarea.Descripcion = oTareas.Descripcion;
                tarea.Color = oTareas.Color;
                tarea.FechaInicio = oTareas.FechaInicio;
                tarea.FechaFin = oTareas.FechaFin;
                tarea.IdPersona = oTareas.IdPersona;
                tarea.porcentaje = oTareas.porcentaje;
                db.tareas.Add(tarea);
                db.SaveChanges();
            }
        }

        // ACTUALIZAR TAREA
        public void ActualizarTarea(Tareas oTareas)
        {
            using (var db = new TareaEntities1())
            {
                var tareas = (tareas)db.tareas.Where(t => t.Id == oTareas.Id).ToList().First();
                //tareas.Id = oTareas.Id;
                tareas.Titulo = oTareas.Titulo;
                tareas.Descripcion = oTareas.Descripcion;
                tareas.Color = oTareas.Color;
                tareas.FechaInicio = oTareas.FechaInicio;
                tareas.FechaFin = oTareas.FechaFin;
                tareas.IdPersona = oTareas.IdPersona;
                tareas.porcentaje = oTareas.porcentaje;
                db.Entry(tareas).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        // ELIMINAR TAREA
        public void EliminarTarea(int id)
        {
            using (var db = new TareaEntities1())
            {
                var tarea = db.tareas.Where(t => t.Id == id).First();
                db.tareas.Remove(tarea);
                db.SaveChanges();
            }
        }

        // MOSTRAR TAREAS PROXIMAS A VENCER
        public List<Tareas> MostrarTareasProximasVencer(int id)
        {
            var now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            using (var db = new TareaEntities1())
            {

                var tareas = db.tareas.Where(t => SqlFunctions.DateDiff("dd", now, t.FechaFin) < 5
                                            && SqlFunctions.DateDiff("dd", now, t.FechaFin) > 0
                                            && t.IdPersona == id)
                                      .Select(t => new Tareas
                                      {
                                          Id = t.Id,
                                          Titulo = t.Titulo,
                                          Descripcion = t.Descripcion,
                                          Color = t.Color,
                                          FechaInicio = t.FechaInicio,
                                          FechaFin = t.FechaFin,
                                          IdPersona = t.IdPersona,
                                          porcentaje = t.porcentaje
                                      }).ToList();

                if (tareas.Count() > 0)
                    return tareas;
                else
                    return null;
            }
        }

        // Tareas que esten a 15 min de comenzar
        public bool TareasProximasComenzar(int id)
        {
            var now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            using (var db = new TareaEntities1())
            {
                var time = DateTime.Now.AddMinutes(5);

                var result = db.tareas.Where(t => SqlFunctions.DateDiff("MI", now, t.FechaInicio) > 0 
                                                && SqlFunctions.DateDiff("MI", now, t.FechaInicio) < 4 
                                                && t.IdPersona == id).ToList();

                return result.Count() > 0;
                
            }
        }

        // MOSTRAR TAREAS PROXIMAS A COMENZAR
        public List<Tareas> MostrarTareasProximasComenzar(int id)
        {
            var now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            using (var db = new TareaEntities1())
            {

                var tareas = db.tareas.Where(t => SqlFunctions.DateDiff("MI", now, t.FechaInicio) > 0
                                                && SqlFunctions.DateDiff("MI", now, t.FechaInicio) < 4
                                                && t.IdPersona == id)
                                      .Select(t => new Tareas
                                      {
                                          Id = t.Id,
                                          Titulo = t.Titulo,
                                          Descripcion = t.Descripcion,
                                          Color = t.Color,
                                          FechaInicio = t.FechaInicio,
                                          FechaFin = t.FechaFin,
                                          IdPersona = t.IdPersona,
                                          porcentaje = t.porcentaje
                                      }).ToList();

                if (tareas.Count() > 0)
                    return tareas;
                else
                    return null;
            }
        }


        // BUSCAR TAREA
        [WebMethod]
        public List<Tareas> BuscarTareas(string titulo)
        {
            using (var db = new TareaEntities1())
            {
                var list = db.tareas.Where(t => t.Titulo.Contains(titulo))
                                    .Select(t => new Tareas {
                                        Id = t.Id,
                                        Titulo = t.Titulo,
                                        Descripcion = t.Descripcion,
                                        Color = t.Color,
                                        FechaInicio = t.FechaInicio,
                                        FechaFin = t.FechaFin,
                                        IdPersona = t.IdPersona,
                                        porcentaje = t.porcentaje
                                    }).ToList();
                return list;
            }
        }

        // BUSCAR TAREA COMPLETADAS
        [WebMethod]
        public List<Tareas> BuscarTareasCompletadas(string titulo, int id)
        {
            using (var db = new TareaEntities1())
            {
                var list = db.tareas.Where(t => t.Titulo.Contains(titulo) && t.porcentaje == 100 
                                            && t.IdPersona == id)
                                    .Select(t=> new Tareas {
                                        Id = t.Id,
                                        Titulo = t.Titulo,
                                        Descripcion = t.Descripcion,
                                        Color = t.Color,
                                        FechaInicio = t.FechaInicio,
                                        FechaFin = t.FechaFin,
                                        IdPersona = t.IdPersona,
                                        porcentaje = t.porcentaje
                                    }).ToList();

                   return list;
            }
        }

        // MOSTRAR TAREAS COMPLETADAS
        [WebMethod]
        public List<Tareas> MostrarTareasCompletadas(int id)
        {
            using (var db = new TareaEntities1())
            {
                var list = db.tareas.Where(t => t.porcentaje == 100 && t.IdPersona == id)
                                    .Select(t=> new Tareas { 
                                        Id = t.Id,
                                        Titulo = t.Titulo,
                                        Descripcion = t.Descripcion,
                                        Color = t.Color,
                                        FechaInicio = t.FechaInicio,
                                        FechaFin = t.FechaFin,
                                        IdPersona = t.IdPersona,
                                        porcentaje = t.porcentaje
                                    }).ToList();
                return list;
            }
        }

        // BUSCAR TAREAS PENDIENTES
        [WebMethod]
        public List<Tareas> BuscarTareasPendientes(string titulo, int id)
        {
            using (var db = new TareaEntities1())
            {
                List<Tareas> listaTareas = new List<Tareas>();
                var list = db.tareas.Where(t => t.Titulo.Contains(titulo) && t.porcentaje < 100 
                                            && t.IdPersona == id)
                                    .Select(t=> new Tareas { 
                                        Id = t.Id,
                                        Titulo = t.Titulo,
                                        Descripcion = t.Descripcion,
                                        Color = t.Color,
                                        FechaInicio = t.FechaInicio,
                                        FechaFin = t.FechaFin,
                                        IdPersona = t.IdPersona,
                                        porcentaje = t.porcentaje
                                    }).ToList();
                return list;
            }
        }

        // MOSTRAR TAREAS PENDIENTES
        [WebMethod]
        public List<Tareas> MostrarTareasPendientes(int id)
        {
            using (var db = new TareaEntities1())
            {
                var list = db.tareas.Where(t => t.porcentaje < 100 && t.IdPersona == id)
                                    .Select(t=> new Tareas { 
                                        Id = t.Id,
                                        Titulo = t.Titulo,
                                        Descripcion = t.Descripcion,
                                        Color = t.Color,
                                        FechaInicio = t.FechaInicio,
                                        FechaFin = t.FechaFin,
                                        IdPersona = t.IdPersona,
                                        porcentaje = t.porcentaje
                                    }).ToList();
                return list;
            }
        }

        // BUSCAR TAREAS SIN COMENZAR
        [WebMethod]
        public List<Tareas> BuscarTareasSinComenzar(string titulo, int id)
        {
            using (var db = new TareaEntities1())
            {
                List<Tareas> listaTareas = new List<Tareas>();
                var list = db.tareas.Where(t => t.Titulo.Contains(titulo) && t.porcentaje == 0 
                                            && t.IdPersona == id)
                                    .Select(t=> new Tareas { 
                                        Id = t.Id,
                                        Titulo = t.Titulo,
                                        Descripcion = t.Descripcion,
                                        Color  = t.Color,
                                        FechaInicio = t.FechaInicio,
                                        FechaFin = t.FechaFin,
                                        IdPersona = t.IdPersona,
                                        porcentaje = t.porcentaje
                                    }).ToList();
                return list;
            }
        }

        // MOSTRAR TAREAS SIN COMENZAR
        [WebMethod]
        public List<Tareas> MostrarTareasSinComenzar(int id)
        {
            using (var db = new TareaEntities1())
            {
                List<Tareas> listaTareas = new List<Tareas>();
                var list = db.tareas.Where(t => t.porcentaje == 0 && t.IdPersona == id)
                                    .Select(t=> new Tareas { 
                                        Id = t.Id,
                                        Titulo = t.Titulo,
                                        Descripcion = t.Descripcion,
                                        Color = t.Color,
                                        FechaInicio = t.FechaInicio,
                                        FechaFin = t.FechaFin,
                                        IdPersona = t.IdPersona,
                                        porcentaje = t.porcentaje
                                    }).ToList();
                return list;
            }
        }

        // REGISTRAR USUARIO
        public void RegistrarUsuario(Persona p, Usuario u)
        {
            using (var db = new TareaEntities1())
            {
                usuario usu = new usuario();
                usu.nick = u.nick;
                usu.clave = u.clave;
                db.usuario.Add(usu);
                db.SaveChanges();

                // Obtener id del usuario ingresado
                var id = ObtenerUltimoId();

                persona person = new persona();
                person.nombre = p.nombre;
                person.apellido = p.apellido;
                person.direccion = p.direccion;
                person.dni = p.dni;
                person.telefono = p.telefono;
                person.IdUsuario = id;
                db.persona.Add(person);
                db.SaveChanges();
            }
        }

        // ACCEDER AL SISTEMA
        public bool Acceder(Usuario usuario)
        {
            try
            {
                using (var db = new TareaEntities1())
                {
                    var tarea = db.usuario.Where(u => u.nick == usuario.nick && u.clave == usuario.clave).FirstOrDefault();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hubo un error" + ex);
                return false;
            }
        }

        public Usuario GetUsuario(string nick, string clave)
        {
            using (var db = new TareaEntities1())
            {
                Usuario usu = new Usuario();
                var usuario = db.usuario.Where(u => u.nick == nick && u.clave == clave).ToList<usuario>().First();
                usu.Id = usuario.Id;
                usu.nick = usuario.nick;
                usu.clave = usuario.clave;
                return usu;
            }
        }

        public int ObtenerUltimoId()
        {
            using (var db = new TareaEntities1())
            {
                var tareas = db.tareas.SqlQuery("SELECT MAX(Id) as Id FROM usuario").ToList();
                foreach (var tarea in tareas)
                {
                    int Id = tarea.Id;
                    return Id;
                }
            }
            return 0;
        }
    }
}
