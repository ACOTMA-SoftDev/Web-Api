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
        AsignacionServicio service = new AsignacionServicio();        
        [HttpPost]
        public bool agregarServicio(List<AsignacionEntity> oService)
        {
            bool response = false;
            try                
            {
                for (int i = 0; i < oService.Count; i++)
                {
                    service.addAsignacion(oService[i]);
                }
                response = true;
            }catch(Exception e)
            {
                string ex = e.Message;
                Console.WriteLine(ex);
            }
            return response;            
        }
        [Route("api/UpdateAsignacion")]
        [HttpPost]
        public bool updateAsigancion(AsignacionEntity uAsignacion)
        {
            return service.UpdateAsignacion(uAsignacion);
        }
        
        [HttpGet]
        public List<MatchAsignHorario> asignaciones(string fkFecha)
        {
            DateTime f= DateTime.Parse(fkFecha);
            var lista = service.asignHorarios(f);
            return lista.ToList();
        }
        [Route("api/consultarAsignacionDay")]
        [HttpGet]
        public List<AsignacionEntity> getAsignacionDay()
        {
            return service.consultarAsignacionDay();
        }

    }
}
