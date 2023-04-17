using Acotma_API.Models_DB;
using Acotma_API.Models_DB.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acotma_API.serviciosModels
{
    public class HorarioServicioService
    {
        readonly ACOTMADBEntities DB = new ACOTMADBEntities(); // Se crea una instancia de la clase ACOTMADBEntities para acceder a la base de datos

        public bool AddHorarios(int corrida, string ruta, TimeSpan horarioSalida, DateTime fecha)
        {
            bool response = false; // Se inicializa la variable de respuesta en falso
            try
            {
                // Se crea un nuevo objeto de tipo horarioServicio con los datos proporcionados
                horarioServicio addHorario = new horarioServicio
                {
                    corrida = corrida,
                    fecha = fecha,
                    ruta = ruta,
                    horarioSalida = horarioSalida
                };
                DB.horarioServicio.Add(addHorario); // Se agrega el objeto a la tabla horarioServicio en la base de datos
                DB.SaveChanges(); // Se guardan los cambios en la base de datos
                response = true; // Se actualiza la variable de respuesta a verdadero
            }
            catch (Exception e)
            {
                string ex = e.Message; // Se captura cualquier excepción que ocurra y se guarda en una variable
                Console.WriteLine(ex); // Se muestra la excepción en la consola (esto podría ser útil para fines de depuración)
            }
            return response; // Se devuelve la variable de respuesta
        }

        public List<HorarioServicioEntity> GetHorarios()
        {
            var horarioEncrypt = DB.horarioServicio.ToList<horarioServicio>(); // Se obtienen los datos de la tabla horarioServicio de la base de datos y se convierten en una lista
            List<HorarioServicioEntity> horarioDecrypt = new List<HorarioServicioEntity>(); // Se crea una nueva lista de tipo HorarioServicioEntity para almacenar los datos desencriptados
            foreach (horarioServicio horario in horarioEncrypt)
            {
                // Se recorren los datos obtenidos y se agregan a la lista 'horarioDecrypt' como objetos de tipo HorarioServicioEntity
                horarioDecrypt.Add(new HorarioServicioEntity
                {
                    corrida = horario.corrida,
                    fecha = horario.fecha,
                    horarioSalida = (TimeSpan)horario.horarioSalida,
                    ruta = horario.ruta
                });
            }
            return horarioDecrypt; // Se devuelve la lista de datos desencriptados
        }

        public List<HorarioServicioEntity> ConsultarHorarioDay()
        {
            // Crear una nueva lista para almacenar los resultados
            List<HorarioServicioEntity> conHora = new List<HorarioServicioEntity>();

            // Consultar la tabla horarioServicio usando LINQ to Entities
            var datah = from hora in DB.horarioServicio
                        where (hora.fecha == DateTime.Today) // Filtrar por fecha igual a la fecha de hoy
                        select new // Crear un nuevo tipo anónimo con las propiedades seleccionadas
                        {
                            hora.corrida,
                            hora.fecha,
                            hora.ruta,
                            hora.horarioSalida
                        };
            datah.ToList(); // Ejecutar la consulta y materializar los resultados en una lista
            foreach (var dataHora in datah)
            {
                var dataASi = dataHora;
                conHora.Add(new HorarioServicioEntity
                {
                    // Agregar un nuevo objeto HorarioServicioEntity a la lista con los datos seleccionados
                    corrida = dataHora.corrida,
                    fecha = dataHora.fecha,
                    ruta = dataHora.ruta,
                    horarioSalida = (TimeSpan)dataHora.horarioSalida
                });
            }
            return conHora; // Retornar la lista de resultados
        }
        public List<HorarioServicioEntity> GetCorridaToday(int fkCorrida)
        {
            // Crear una nueva lista para almacenar los resultados
            List<HorarioServicioEntity> conHora = new List<HorarioServicioEntity>();

            // Consultar la tabla horarioServicio usando LINQ to Entities
            var datah = from hora in DB.horarioServicio
                        where ((hora.fecha == DateTime.Today) && (hora.corrida == fkCorrida)) // Filtrar por fecha igual a la fecha de hoy y corrida igual a fkCorrida
                        select new // Crear un nuevo tipo anónimo con las propiedades seleccionadas
                        {
                            hora.corrida,
                            hora.fecha,
                            hora.ruta,
                            hora.horarioSalida
                        };
            datah.ToList(); // Ejecutar la consulta y materializar los resultados en una lista
            foreach (var dataHora in datah)
            {
                var dataASi = dataHora;
                conHora.Add(new HorarioServicioEntity
                {
                    // Agregar un nuevo objeto HorarioServicioEntity a la lista con los datos seleccionados
                    corrida = dataHora.corrida,
                    fecha = dataHora.fecha,
                    ruta = dataHora.ruta,
                    horarioSalida = (TimeSpan)dataHora.horarioSalida
                });
            }
            return conHora; // Retornar la lista de resultados
        }

        public bool DeleteHorarioServicio(eliminarHorarioServicio fecha)
        {
            bool response = false;
            try
            {
                var eliminarHoarios = DB.horarioServicio; // Obtener la tabla horarioServicio
                var deletHorarioServicio = eliminarHoarios.Where(a => a.fecha == fecha.fechaDelete &&
                a.ruta == fecha.rutaDelete); // Filtrar los registros por fecha y ruta especificadas
                DB.horarioServicio.RemoveRange(deletHorarioServicio); // Eliminar los registros filtrados
                DB.SaveChanges(); // Guardar los cambios en la base de datos
                response = true; // Establecer la respuesta como verdadera si la eliminación fue exitosa
            }
            catch (Exception e)
            {
                String mensaje = e.Message; // Capturar cualquier excepción y almacenar su mensaje en una variable
            }
            return response; // Retornar la respuesta indicando si la eliminación fue exitosa o no
        }

        public List<SelectIdFecha> GetFechaCorrida()
        {
            DateTime today = DateTime.Today; // Obtener la fecha actual
            List<SelectIdFecha> selectHorario = new List<SelectIdFecha>(); // Crear una nueva lista para almacenar los resultados

            var selectData = DB.horarioServicio.
                Where(h => h.fecha >= today). // Filtrar por registros con fecha mayor o igual a la fecha actual
                GroupBy(h => new { h.fecha, h.ruta }). // Agrupar por fecha y ruta
                ToList(); // Convertir los resultados a una lista
            foreach (var dataHora in selectData)
            {
                var dataASi = dataHora;
                selectHorario.Add(new SelectIdFecha
                {
                    // Agregar un nuevo objeto SelectIdFecha a la lista con los datos seleccionados
                    fecha = dataHora.Key.fecha,
                    ruta = dataHora.Key.ruta
                });
            }
            return selectHorario; // Retornar la lista de resultados
        }
        public List<SelectIdFecha> GetFecha()
        {
            List<SelectIdFecha> selectHorario = new List<SelectIdFecha>(); // Crear una nueva lista para almacenar los resultados
            var datah = DB.horarioServicio
                        .Select(h => new { fecha = h.fecha }) // Seleccionar la fecha de la tabla horarioServicio
                        .Distinct(); // Obtener valores distintos de fecha
            datah.ToList(); // Convertir los resultados a una lista (esto puede no ser necesario)
            foreach (var dataHora in datah)
            {
                var dataASi = dataHora;
                selectHorario.Add(new SelectIdFecha
                {
                    // Agregar un nuevo objeto SelectIdFecha a la lista con la fecha seleccionada
                    fecha = dataHora.fecha
                });
            }
            return selectHorario; // Retornar la lista de resultados
        }

        public bool DeleteAll()
        {
            bool response = false;
            DateTime time = DateTime.Today; // Obtener la fecha actual
            try
            {
                var selectHorarios = DB.horarioServicio.Where(x => x.fecha >= time); // Filtrar registros por fecha mayor o igual a la fecha actual
                DB.horarioServicio.RemoveRange(selectHorarios); // Eliminar los registros filtrados
                DB.SaveChanges(); // Guardar los cambios en la base de datos
                response = true; // Establecer la respuesta como verdadera si la eliminación fue exitosa
            }
            catch (Exception ex)
            {
                throw ex; // Lanzar la excepción si ocurre algún error
            }
            return response; // Retornar la respuesta indicando si la eliminación fue exitosa o no
        }
    }
}