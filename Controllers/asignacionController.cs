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
    public class AsignacionController : ApiController
    {
        readonly AsignacionServicio service = new AsignacionServicio();
        readonly HorarioServicioService hServ = new HorarioServicioService();
        [Authorize(Roles ="Operadora")]
        [HttpPost]
        public bool AgregarServicio(List<AsignacionEntity> oService)
        {
            _ = new List<HorarioServicioEntity>();
            bool response = false;
            try
            {
                for (int i = 0; i < oService.Count; i++)
                {
                    List<HorarioServicioEntity> horario = hServ.GetCorridaToday(oService[i].fkCorrida);
                    if (horario.Count>0) { 
                    service.AddAsignacion(oService[i]);
                    }
                }
                response = true;
            }
            catch (Exception e)
            {
                string ex = e.Message;
                Console.WriteLine(ex);
            }
            return response;
        }
        [Authorize(Roles = "Operadora")]
        [Route("api/UpdateAsignacion")]
        [HttpPost]
        public bool UpdateAsigancion(AsignacionEntity uAsignacion)
        {
            return service.UpdateAsignacion(uAsignacion);
        }
        [HttpGet]
        public List<MatchAsignHorario> Asignaciones(string fkFecha)
        {
            DateTime f = DateTime.Parse(fkFecha);
            var lista = service.AsignHorarios(f);
            return lista.ToList();
        }
        [Authorize(Roles = "Operadora")]
        [Route("api/consultarAsignacionDay")]
        [HttpGet]
        public List<AsignacionEntity> GetAsignacionDay()
        {
            return service.ConsultarAsignacionDay();
        }
    }
}   