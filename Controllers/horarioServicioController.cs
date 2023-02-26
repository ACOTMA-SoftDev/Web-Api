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
    public class horarioServicioController : ApiController
    {
        horarioServicioService service = new horarioServicioService();
        [HttpPost]
        public bool insertHorario(OperacionesHorario obj)
        {
            bool response = false;
            try
            {
                for (DateTime fecha = obj.fechaInicio; fecha <= obj.fechaFinal; fecha = fecha.AddDays(1))
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
        public List<horarioServicioEntity> GetHorarios()
        {
            return service.GetHorarios();
        }
    }
}
