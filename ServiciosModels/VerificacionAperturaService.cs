using Acotma_API.Models_DB;
using Acotma_API.Models_DB.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acotma_API.ServiciosModels
{
    public class VerificadoresService
    {
        private readonly ACOTMADBEntities DB = new ACOTMADBEntities();  // Declaración de una variable de solo lectura llamada DB del tipo ACOTMADBEntities

        public List<GetServVerificadores> GetServiceVerficadores(int idAsignacion) // Declaración de un método llamado GetServiceVerificadores que toma un parámetro int llamado idAsignacion y devuelve una lista de objetos del tipo GetServVerificadores
        {
            DateTime date = DateTime.Today; // Obtiene la fecha actual del sistema y la almacena en una variable llamada date
            List<GetServVerificadores> data = new List<GetServVerificadores>(); // Crea una nueva lista vacía de objetos del tipo GetServVerificadores llamada data

            // Realiza una consulta LINQ en las entidades DB.asignacion y DB.horarioServicio
            // Se realiza un join entre las tablas asignacion y horarioServicio en base a las claves foráneas fkCorrida y corrida respectivamente
            // Se filtra la consulta con tres condiciones: que la fecha de horarioServicio sea igual a la fecha actual, que la fkFecha de asignacion sea igual a la fecha actual, y que el idAsignacion sea igual al parámetro idAsignacion
            // Luego se realiza una proyección a un nuevo objeto anónimo con ciertos campos seleccionados
            var servVerificadores = from asig in DB.asignacion
                                    join hour in DB.horarioServicio
                                    on asig.fkCorrida equals hour.corrida
                                    where ((hour.fecha == date) && (asig.fkFecha == date) && (asig.idAsignacion == idAsignacion))
                                    select new
                                    {
                                        asig.idAsignacion,
                                        asig.tipoUnidad,
                                        hour.ruta,
                                        asig.economico,
                                        asig.tarjeton,
                                        asig.nomChofer,
                                        hour.corrida,
                                        hour.horarioSalida,
                                        hour.horaLlegada,
                                        hour.fecha
                                    };
            servVerificadores.ToList(); // Ejecuta la consulta y la convierte en una lista, aunque los resultados no se almacenan en ninguna variable

            // Recorre los resultados de la consulta y los agrega a la lista data como objetos del tipo GetServVerificadores
            foreach (var asigH in servVerificadores)
            {
                data.Add(new GetServVerificadores
                {
                    corrida = asigH.corrida,
                    economico = (int)asigH.economico,
                    tarjeton = (int)asigH.tarjeton,
                    horarioSalida = (TimeSpan)asigH.horarioSalida,
                    idAsignacion = asigH.idAsignacion,
                    nomChofer = asigH.nomChofer,
                    ruta = asigH.ruta,
                    tipoUnidad = asigH.tipoUnidad,
                    fecha = asigH.fecha
                });
            }

            return data; // Devuelve la lista de objetos GetServVerificadores
        }

        public List<GetServVerificadores> GetServiceVerficadores()
        {
            // Se obtiene la fecha actual
            DateTime date = DateTime.Today;
            // Se crea un objeto TimeSpan con la hora "00:00"
            TimeSpan timeGet = TimeSpan.Parse("00:00");
            // Se crea una nueva lista de objetos del tipo GetServVerificadores
            List<GetServVerificadores> data = new List<GetServVerificadores>();

            // Se realiza una consulta a la base de datos usando linq
            var servVerificadores = from asig in DB.asignacion
                                    join hour in DB.horarioServicio
                                    on asig.fkCorrida equals hour.corrida
                                    where ((hour.fecha == date) &&
                                    (asig.fkFecha == date) &&
                                    (hour.horaLlegada == timeGet)
                                    && (asig.nomChofer != "FALTA DE UNIDAD"))
                                    select new
                                    {
                                        asig.idAsignacion,
                                        asig.tipoUnidad,
                                        hour.ruta,
                                        asig.economico,
                                        asig.tarjeton,
                                        asig.nomChofer,
                                        hour.corrida,
                                        hour.horarioSalida,
                                        hour.horaLlegada,
                                    };
            // Se ejecuta la consulta y se almacenan los resultados en servVerificadores

            servVerificadores.ToList();

            // Se recorre el resultado de la consulta y se agregan los datos a la lista "data"
            foreach (var asigH in servVerificadores)
            {
                data.Add(new GetServVerificadores
                {
                    corrida = asigH.corrida,
                    economico = (int)asigH.economico,
                    tarjeton = (int)asigH.tarjeton,
                    horarioSalida = (TimeSpan)asigH.horarioSalida,
                    idAsignacion = asigH.idAsignacion,
                    nomChofer = asigH.nomChofer,
                    ruta = asigH.ruta,
                    tipoUnidad = asigH.tipoUnidad,
                    horarioLlegada = asigH.horaLlegada

                });
            }
            // Se retorna la lista "data" con los objetos GetServVerificadores
            return data;
        }
        public bool UpdateVerificacion(VerificacionSalidaEntity salidaEntity)
        {
            bool response = false;
            try
            {
                // Se crea un nuevo objeto verificacionSalida con los datos de salidaEntity
                verificacionSalida verificacion = (new verificacionSalida
                {
                    estado = salidaEntity.Estado,
                    observaciones = salidaEntity.Observaciones,
                    horaSalida = salidaEntity.HoraSalida,
                });

                // Se busca en la base de datos la entidad verificacionSalida correspondiente al idVerificacionSalida de salidaEntity
                verificacionSalida salida = DB.verificacionSalida.FirstOrDefault(a => a.idVerificacionSalida == salidaEntity.IdVerificacionSalida);

                // Se actualizan los campos de la entidad salida con los valores del nuevo objeto verificacion
                salida.idVerificacionSalida = verificacion.idVerificacionSalida;

                // Se guarda el cambio en la base de datos
                DB.SaveChanges();

                response = true;
            }
            catch (Exception e)
            {
                // En caso de error, se captura la excepción pero no se hace nada con ella
                e.Message.ToString();
            }
            // Se retorna el valor de response indicando si la actualización fue exitosa o no
            return response;
        }
        public bool AddVerificacion(VerificacionSalidaEntity newVeriSalida)
        {
            bool response = false;
            try
            {
                // Se crea un nuevo objeto verificacionSalida con los datos de newVeriSalida
                verificacionSalida addVerifi = (new verificacionSalida
                {
                    estado = newVeriSalida.Estado,
                    observaciones = newVeriSalida.Observaciones,
                    CiclosPerdidos = newVeriSalida.ciclosPerdidos,
                    horaSalida = newVeriSalida.HoraSalida,
                    fkasignacion = newVeriSalida.Fkasignacion,
                    fkusuario = newVeriSalida.Fkusuario
                });

                // Se agrega el nuevo objeto verificacionSalida a la colección verificacionSalida en la base de datos
                DB.verificacionSalida.Add(addVerifi);

                // Se guarda el cambio en la base de datos
                DB.SaveChanges();

                response = true;
            }
            catch (Exception e)
            {
                // En caso de error, se captura la excepción pero no se hace nada con ella
                String ex = e.Message;
                Console.WriteLine(ex);
            }
            // Se retorna el valor de response indicando si la inserción fue exitosa o no
            return response;
        }
        public bool LiberarUnidades(HorarioServicioEntity obj)
        {
            bool response = false;
            // Se busca en la base de datos un registro de horarioServicio que coincida con la corrida y fecha proporcionados
            var verificacion = DB.horarioServicio.FirstOrDefault(x =>
            x.corrida == obj.corrida &&
            x.fecha == obj.fecha);
            if (verificacion != null)
            {
                // Se actualiza la hora de llegada del registro encontrado con la hora de llegada proporcionada
                verificacion.horaLlegada = obj.horaLlegada;
                // Se guardan los cambios en la base de datos
                DB.SaveChanges();
                response = true;
            }
            return response;
        }

        public bool EliminarVerificacion(EliminarVerificacionEntity eliminar)
        {
            bool response = false;
            DateTime getToday = DateTime.Today;
            try
            {
                // Se busca en la base de datos un registro de horarioServicio que coincida con la fecha actual y la corrida proporcionada
                var setHorario = DB.horarioServicio.FirstOrDefault(x => x.fecha == getToday && x.corrida == eliminar.corrida);
                // Se busca en la base de datos un registro de verificacionSalida que coincida con el idAsignacion proporcionado
                var dropVerificacion = DB.verificacionSalida.FirstOrDefault(x => x.fkasignacion == eliminar.idAsignacion);
                if (setHorario != null)
                {
                    TimeSpan hora = TimeSpan.Zero;
                    // Se actualiza la hora de llegada del registro de horarioServicio encontrado a la hora cero
                    setHorario.horaLlegada = hora;
                    // Se guardan los cambios en la base de datos
                    DB.SaveChanges();
                    if (dropVerificacion != null)
                    {
                        // Se elimina el registro de verificacionSalida encontrado de la base de datos
                        DB.verificacionSalida.Remove(dropVerificacion);
                        // Se guardan los cambios en la base de datos
                        DB.SaveChanges();
                    }
                    response = true;
                }
            }
            catch (Exception ex)
            {
                // En caso de error, se lanza la excepción
                throw ex;
            }
            return response;
        }

        public bool ActualizarAsignacion(GetServVerificadores update)
        {
            bool response = false;
            try
            {
                // Se busca en la base de datos una asignación que coincida con el idAsignacion proporcionado
                var selectAsignacion = DB.asignacion.FirstOrDefault(x => x.idAsignacion == update.idAsignacion);
                // Se actualizan los datos de la asignación encontrada con los datos proporcionados en el objeto "update"
                selectAsignacion.economico = update.economico;
                selectAsignacion.tarjeton = update.tarjeton;
                // Se guardan los cambios en la base de datos
                DB.SaveChanges();
                response = true;
            }
            catch (Exception ex)
            {
                // En caso de error, se lanza la excepción
                throw ex;
            }
            return response;
        }
    }
}