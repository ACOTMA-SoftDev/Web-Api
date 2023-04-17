using Acotma_API.Models_DB; // Se importa el espacio de nombres Models_DB
using Acotma_API.Models_DB.EntityModels; // Se importa el espacio de nombres Models_DB.EntityModels
using System; // Se importa el espacio de nombres System
using System.Collections.Generic; // Se importa el espacio de nombres System.Collections.Generic
using System.Linq; // Se importa el espacio de nombres System.Linq
using System.Web; // Se importa el espacio de nombres System.Web

namespace Acotma_API.serviciosModels // Se define el namespace Acotma_API.serviciosModels
{
    public class AsignacionServicio // Se define la clase AsignacionServicio
    {
        readonly ACOTMADBEntities DB = new ACOTMADBEntities(); // Se crea una instancia de ACOTMADBEntities

        public bool AddAsignacion(AsignacionEntity newAsignacion) // Se define el método AddAsignacion que recibe un objeto del tipo AsignacionEntity como parámetro
        {
            bool response = false; // Se inicializa la variable de respuesta en falso

            try // Se inicia un bloque try-catch para manejar excepciones
            {
                asignacion insertAsignacion = (new asignacion // Se crea una nueva instancia de asignacion con los datos de newAsignacion
                {
                    tipoUnidad = newAsignacion.tipoUnidad,
                    economico = newAsignacion.economico,
                    tarjeton = newAsignacion.tarjeton,
                    nomChofer = newAsignacion.nomChofer,
                    fkCorrida = newAsignacion.fkCorrida,
                    fkFecha = DateTime.Now
                });

                DB.asignacion.Add(insertAsignacion); // Se agrega la nueva asignacion a la base de datos
                DB.SaveChanges(); // Se guardan los cambios en la base de datos
                response = true; // Se actualiza la variable de respuesta a verdadero
            }
            catch (Exception e) // Se captura cualquier excepción que ocurra
            {
                string ex = e.Message; // Se guarda el mensaje de la excepción en una variable
                Console.WriteLine(ex); // Se imprime el mensaje de la excepción en la consola (esto puede ser útil para propósitos de depuración)
            }

            return response; // Se retorna la variable de respuesta
        }

        public bool UpdateAsignacion(AsignacionEntity asigna) // Se define el método UpdateAsignacion que recibe un objeto del tipo AsignacionEntity como parámetro
        {
            bool response = false; // Se inicializa la variable de respuesta en falso

            try // Se inicia un bloque try-catch para manejar excepciones
            {
                asignacion newAsignacion = (new asignacion // Se crea una nueva instancia de asignacion con los datos de asigna
                {
                    tipoUnidad = asigna.tipoUnidad,
                    economico = asigna.economico,
                    tarjeton = asigna.tarjeton,
                    nomChofer = asigna.nomChofer
                });

                asignacion oldAsigancion = DB.asignacion.FirstOrDefault(a => a.idAsignacion == asigna.idAsignacion); // Se obtiene la asignacion existente en la base de datos que corresponde al idAsignacion del objeto asigna
                oldAsigancion.idAsignacion = newAsignacion.idAsignacion; // Se actualiza la asignación existente con los nuevos valores
                DB.SaveChanges(); // Se guardan los cambios en la base de datos
                response = true; // Se establece la variable de respuesta como verdadera
            }
            catch (Exception e) // Se maneja cualquier excepción que pueda ocurrir
            {
                string ex = e.Message; // Se obtiene el mensaje de la excepción
                Console.WriteLine(ex); // Se imprime el mensaje en la consola
            }
            return response; // Se devuelve la respuesta
        }
        public List<MatchAsignHorario> AsignHorarios(DateTime fecha)
        {
            List<MatchAsignHorario> hServ = new List<MatchAsignHorario>(); // Se crea una lista vacía para almacenar los resultados
            var data = from asig in DB.asignacion // Se realiza una consulta LINQ para obtener las asignaciones de horarios de servicio
                       join horario in DB.horarioServicio
                       on asig.fkCorrida equals horario.corrida
                       where ((horario.fecha == fecha) && (asig.fkFecha == fecha)) // Se filtran los resultados por la fecha especificada
                       select new // Se crea una nueva instancia anónima con los campos seleccionados
                       {
                           asig.idAsignacion,
                           asig.tipoUnidad,
                           asig.economico,
                           asig.tarjeton,
                           asig.nomChofer,
                           asig.fkCorrida,
                           asig.fkFecha,
                           horario.corrida,
                           horario.fecha,
                           horario.ruta
                       };
            data.ToList(); // Se ejecuta la consulta y se convierte el resultado a una lista
            foreach (var dataHS in data) // Se itera a través de los resultados obtenidos
            {
                hServ.Add(new MatchAsignHorario // Se crea una nueva instancia de MatchAsignHorario y se agrega a la lista
                {
                    idAsignacion = dataHS.idAsignacion,
                    tipoUnidad = dataHS.tipoUnidad,
                    economico = (int)dataHS.economico,
                    tarjeton = (int)dataHS.tarjeton,
                    nomChofer = dataHS.nomChofer,
                    fkCorrida = (int)dataHS.fkCorrida,
                    fkFecha = (DateTime)dataHS.fkFecha,
                    corrida = dataHS.corrida,
                    fecha = dataHS.fecha,
                    ruta = dataHS.ruta
                });
            }
            return hServ; // Se devuelve la lista de asignaciones de horarios de servicio
        }

        public List<AsignacionEntity> ConsultarAsignacionDay()
        {
            List<AsignacionEntity> conAsig = new List<AsignacionEntity>(); // Se crea una lista vacía para almacenar los resultados
            var data = from cons in DB.asignacion // Se realiza una consulta LINQ para obtener las asignaciones de horarios de servicio
                       where (cons.fkFecha == DateTime.Today) // Se filtran los resultados por la fecha actual (hoy)
                       select new // Se crea una nueva instancia anónima con los campos seleccionados
                       {
                           cons.idAsignacion,
                           cons.tipoUnidad,
                           cons.economico,
                           cons.tarjeton,
                           cons.nomChofer,
                           cons.fkCorrida,
                           cons.fkFecha
                       };
            data.ToList(); // Se ejecuta la consulta y se convierte el resultado a una lista
            foreach (var dataASi in data) // Se itera a través de los resultados obtenidos
            {
                var dataASi1 = dataASi; // Se crea una variable auxiliar para evitar problemas de captura en el cierre del bucle
                conAsig.Add(new AsignacionEntity // Se crea una nueva instancia de AsignacionEntity y se agrega a la lista
                {
                    idAsignacion = dataASi.idAsignacion,
                    tipoUnidad = dataASi.tipoUnidad,
                    economico = (int)dataASi.economico,
                    tarjeton = (int)dataASi.tarjeton,
                    nomChofer = dataASi.nomChofer,
                    fkCorrida = (int)dataASi.fkCorrida,
                    fkFecha = (DateTime)dataASi.fkFecha
                });
            }
            return conAsig; // Se devuelve la lista de asignaciones de horarios de servicio
        }
        public List<ServiciosIniciadosEntity> GetServiciosIniciados()
        {
            List<ServiciosIniciadosEntity> servStar = new List<ServiciosIniciadosEntity>(); // Se crea una lista vacía para almacenar los resultados
            var data = from asig in DB.asignacion // Se realiza una consulta LINQ para obtener asignaciones de horarios de servicio
                       join hor in DB.horarioServicio // Se realiza una unión con la tabla de horarios de servicio
                       on asig.fkCorrida equals hor.corrida // Se realiza una unión por la columna fkCorrida de la tabla de asignaciones y la columna corrida de la tabla de horarios de servicio
                       where ((hor.fecha == DateTime.Today) && (asig.fkFecha == DateTime.Today)) // Se filtran los resultados por la fecha actual (hoy) en ambas tablas
                       select new // Se crea una nueva instancia anónima con los campos seleccionados de ambas tablas
                       {
                           idAsignacion = asig.idAsignacion,
                           tipoUnidad = asig.tipoUnidad,
                           economico = asig.economico,
                           tarjeton = asig.tarjeton,
                           nomChofer = asig.nomChofer,
                           fkCorrida = asig.fkCorrida,
                           fkFecha = asig.fkFecha,
                           corrida = hor.corrida,
                           fecha = hor.fecha,
                           ruta = hor.ruta,
                           horarioSalida = hor.horarioSalida,
                           horaLlegada = hor.horaLlegada
                       };
            data.ToList(); // Se ejecuta la consulta y se convierte el resultado a una lista
            foreach (var servicio in data) // Se itera a través de los resultados obtenidos
            {
                var datosServ = servicio; // Se crea una variable auxiliar para evitar problemas de captura en el cierre del bucle
                servStar.Add(new ServiciosIniciadosEntity // Se crea una nueva instancia de ServiciosIniciadosEntity y se agrega a la lista
                {
                    idAsignacion = servicio.idAsignacion,
                    tipoUnidad = servicio.tipoUnidad,
                    economico = (int)servicio.economico,
                    tarjeton = (int)servicio.tarjeton,
                    nomChofer = servicio.nomChofer,
                    fkCorrida = (int)servicio.fkCorrida,
                    fkFecha = (DateTime)servicio.fkFecha,
                    corrida = servicio.corrida,
                    fecha = servicio.fecha,
                    ruta = servicio.ruta,
                    horarioSalida = (TimeSpan)servicio.horarioSalida,
                    horaLlegada = servicio.horaLlegada
                });
            }
            return servStar; // Se devuelve la lista de servicios de transporte iniciados
        }

        /// <summary>
        /// Obtiene una lista de objetos ServiciosIniciadosEntity basados en el idAsignacion proporcionado.
        /// </summary>
        /// <param name="idAsignacion">El idAsignacion para filtrar los resultados.</param>
        /// <returns>Una lista de objetos ServiciosIniciadosEntity.</returns>
        public List<ServiciosIniciadosEntity> GetServiciosIniciadosById(int idAsignacion)
        {
            List<ServiciosIniciadosEntity> servStar = new List<ServiciosIniciadosEntity>();

            // Realiza una consulta a la base de datos mediante una operación de join y where.
            var data = from asig in DB.asignacion
                       join hor in DB.horarioServicio
                       on asig.fkCorrida equals hor.corrida
                       where ((hor.fecha == DateTime.Today) && (asig.idAsignacion == idAsignacion))
                       select new
                       {
                           idAsignacion = asig.idAsignacion,
                           tipoUnidad = asig.tipoUnidad,
                           economico = asig.economico,
                           tarjeton = asig.tarjeton,
                           nomChofer = asig.nomChofer,
                           fkCorrida = asig.fkCorrida,
                           fkFecha = asig.fkFecha,
                           corrida = hor.corrida,
                           fecha = hor.fecha,
                           ruta = hor.ruta,
                           horarioSalida = hor.horarioSalida,
                           horaLlegada = hor.horaLlegada
                       };

            data.ToList(); // Ejecuta la consulta y carga los resultados en memoria.

            // Mapea los resultados a objetos ServiciosIniciadosEntity y los agrega a la lista servStar.
            foreach (var servicio in data)
            {
                var datosServ = servicio;
                servStar.Add(new ServiciosIniciadosEntity
                {
                    idAsignacion = servicio.idAsignacion,
                    tipoUnidad = servicio.tipoUnidad,
                    economico = (int)servicio.economico,
                    tarjeton = (int)servicio.tarjeton,
                    nomChofer = servicio.nomChofer,
                    fkCorrida = (int)servicio.fkCorrida,
                    fkFecha = (DateTime)servicio.fkFecha,
                    corrida = servicio.corrida,
                    fecha = servicio.fecha,
                    ruta = servicio.ruta,
                    horarioSalida = (TimeSpan)servicio.horarioSalida,
                    horaLlegada = servicio.horaLlegada
                });
            }

            return servStar; // Retorna la lista de objetos ServiciosIniciadosEntity.
        }
        /// <summary>
        /// Elimina las asignaciones de hoy de la base de datos.
        /// </summary>
        /// <returns>True si se eliminaron las asignaciones exitosamente, False en caso contrario.</returns>
        public bool DeleteAsignacionToday()
        {
            bool response = false;

            DateTime time = DateTime.Today; // Obtiene la fecha actual.

            try
            {
                var asignaciones = DB.asignacion.Where(x => x.fkFecha == time); // Obtiene las asignaciones que tienen la fecha actual.
                DB.asignacion.RemoveRange(asignaciones); // Remueve las asignaciones de la base de datos.
                DB.SaveChanges(); // Guarda los cambios en la base de datos.
                response = true; // Establece la respuesta como True indicando que se eliminaron las asignaciones exitosamente.
            }
            catch (Exception ex)
            {
                throw ex; // Lanza una excepción en caso de error.
            }

            return response; // Retorna el resultado de la operación de eliminación.
        }
