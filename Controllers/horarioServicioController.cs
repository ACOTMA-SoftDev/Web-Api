using Acotma_API.Models_DB;
using Acotma_API.Models_DB.EntityModels;
using Acotma_API.serviciosModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Acotma_API.Controllers
{
    public class HorarioServicioController : ApiController
    {
        // Se instancia el servicio de HorarioServicio
        readonly HorarioServicioService service = new HorarioServicioService();

        // Endpoint para insertar un nuevo horario de servicio
        [HttpPost]
        public bool InsertHorario(OperacionesHorario obj)
        {
            bool response = false;
            List<SelectIdFecha> horario = new List<SelectIdFecha>();
            horario = GetSelectIdFechas();
            List<SelectIdFecha> fechas = new List<SelectIdFecha>();
            fechas = GetSelectFechas();
            var filtro = horario.Find(x => x.ruta == obj.ruta);
            var filtro3 = horario.Find(x => x.corrida == obj.corridaInicial);
            var filtro2 = fechas.Find(x => x.fecha == DateTime.Parse(obj.fechaInicio));

            // Se verifica si el horario de servicio ya existe en la base de datos
            if (filtro != null && filtro2 != null && filtro3 != null)
            {
                response = false;
            }
            else
            {
                try
                {
                    // Se generan los horarios de servicio para las fechas y corridas especificadas
                    for (DateTime fecha = DateTime.Parse(obj.fechaInicio); fecha <= DateTime.Parse(obj.fechaFinal); fecha = fecha.AddDays(1))
                    {
                        TimeSpan timeSpan = obj.primeraSalida;
                        TimeSpan horaSalida = timeSpan - TimeSpan.FromMinutes(obj.intervalo);
                        for (int corrida = obj.corridaInicial; corrida <= obj.corridaFinal; corrida++)
                        {
                            horaSalida += TimeSpan.FromMinutes(obj.intervalo);
                            service.AddHorarios(corrida, obj.ruta, horaSalida, fecha);
                        }
                    }
                    response = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            // Se retorna la respuesta indicando si se pudo insertar el horario de servicio o no
            return response;
        }
        [HttpGet]
        public List<HorarioServicioEntity> GetHorarios()
        {
            // Este método HTTP de tipo GET recupera una lista de entidades de horario de servicio.
            // Retorna una lista de objetos de tipo HorarioServicioEntity.
            // No tiene ningún parámetro de entrada.
            return service.GetHorarios();
        }

        [HttpGet]
        [Route("api/GetHorarios/Today")]
        public List<HorarioServicioEntity> GetHorarioRutasDay()
        {
            // Este método HTTP de tipo GET recupera una lista de entidades de horario de servicio para el día actual.
            // Retorna una lista de objetos de tipo HorarioServicioEntity.
            // No tiene ningún parámetro de entrada.
            return service.ConsultarHorarioDay();
        }

        [Route("api/DeleteHorarioServicio")]
        [HttpPost]
        public bool DeleteHorarioServicio(eliminarHorarioServicio fecha)
        {
            // Este método HTTP de tipo POST elimina un horario de servicio específico.
            // Toma un parámetro de entrada de tipo eliminarHorarioServicio que contiene la fecha del horario a eliminar.
            // Retorna un valor booleano que indica si la eliminación fue exitosa o no.
            return service.DeleteHorarioServicio(fecha);
        }

        [HttpGet]
        [Route("api/GetHorarios/Today/Id")]
        public List<SelectIdFecha> GetSelectIdFechas()
        {
            // Este método HTTP de tipo GET recupera una lista de objetos de tipo SelectIdFecha que representan las fechas de las corridas para el día actual.
            // Retorna una lista de objetos de tipo SelectIdFecha.
            // No tiene ningún parámetro de entrada.
            return service.GetFechaCorrida();
        }

        [HttpGet]
        [Route("api/GetFechas/Horarios")]
        public List<SelectIdFecha> GetSelectFechas()
        {
            // Este método HTTP de tipo GET recupera una lista de objetos de tipo SelectIdFecha que representan las fechas de las corridas para los horarios disponibles.
            // Retorna una lista de objetos de tipo SelectIdFecha.
            // No tiene ningún parámetro de entrada.
            return service.GetFecha();
        }

        [HttpGet]
        [Route("api/Delete/Horario")]
        public bool DeleteHorario()
        {
            // Este método HTTP de tipo GET elimina todos los horarios de servicio existentes.
            // Retorna un valor booleano que indica si la eliminación fue exitosa o no.
            return service.DeleteAll();
        }
