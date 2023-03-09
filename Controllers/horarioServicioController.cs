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
        HorarioServicioService service = new HorarioServicioService();
        [HttpPost]
        public bool insertHorario(OperacionesHorario obj)
        {
            bool response = false;
            try
            {
                for (DateTime fecha = DateTime.Parse(obj.fechaInicio); fecha <= DateTime.Parse(obj.fechaFinal); fecha = fecha.AddDays(1))
                {
                    TimeSpan timeSpan = obj.primeraSalida;
                    TimeSpan horaSalida = timeSpan - TimeSpan.FromMinutes(obj.intervalo);
                    for (int corrida = obj.corridaInicial; corrida <= obj.corridaFinal; corrida++)
                    {
                        horaSalida += TimeSpan.FromMinutes(obj.intervalo);
                        service.addHorarios(corrida, obj.ruta, horaSalida, fecha);
                    }
                }
                response = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return response;
        }
        [HttpGet]
        public List<HorarioServicioEntity> GetHorarios()
        {
            return service.GetHorarios();
        }
        [HttpGet]
        public List<HorarioServicioEntity> getHorarioRutasDay()
        {
            return service.consultarHorarioDay();
        }
        [Route ("api/DeleteHorarioServicio")]
        [HttpPost]
        public bool DeleteHorarioServicio(eliminarHorarioServicio fecha)
        {
            return service.DeleteHorarioServicio(fecha);
        }
    }
}