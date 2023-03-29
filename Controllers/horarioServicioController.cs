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
        readonly HorarioServicioService service = new HorarioServicioService();        
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
            

            if (filtro !=null && filtro2!=null && filtro3!=null)
            {
                response = false;
            }
            else { 
            try
            {
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



            return response;
        }        
        [HttpGet]
        public List<HorarioServicioEntity> GetHorarios()
        {
            return service.GetHorarios();
        }        
        [HttpGet]
        [Route("api/GetHorarios/Today")]
        public List<HorarioServicioEntity> GetHorarioRutasDay()
        {
            return service.ConsultarHorarioDay();
        }
        [Route ("api/DeleteHorarioServicio")]
        [HttpPost]
        public bool DeleteHorarioServicio(eliminarHorarioServicio fecha)
        {
            return service.DeleteHorarioServicio(fecha);
        }
        [HttpGet]
        [Route("api/GetHorarios/Today/Id")]
        public List<SelectIdFecha> GetSelectIdFechas()
        {
            return service.GetFechaCorrida();
        }
        [HttpGet]
        [Route("api/GetFechas/Horarios")]
        public List<SelectIdFecha> GetSelectFechas()
        {
            return service.GetFecha();
        }
    }
}