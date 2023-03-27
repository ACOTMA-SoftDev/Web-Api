using Acotma_API.Models_DB.EntityModels;
using Acotma_API.ServiciosModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Acotma_API.Controllers
{    
    public class VerificacionAperturaController : ApiController
    {
        private readonly VerificadoresService service = new VerificadoresService();        
        [HttpGet]
        [Route("api/Verificacion/Servicio")]
        public List<GetServVerificadores> GetCheckid(int idAsignacion)
        {
            return service.GetServiceVerficadores(idAsignacion);
        }
        [HttpGet]
        [Route("api/Verificacion/Servicio/Completo")]
        public List<GetServVerificadores> GetCheck()
        {
            return service.GetServiceVerficadores();
        }
        [HttpPost]
        public bool UpdateCheck(VerificacionSalidaEntity verificacion)
        {
            return service.UpdateVerificacion(verificacion);
        }        
        [Route ("api/addverificacion")]
        [HttpPost]
        public bool AgregarVerificacion(VerificacionSalidaEntity oVerificacion)
        {
            return service.AddVerificacion(oVerificacion);
        }
        [HttpPost]
        [Route("api/Liberar/Unidades")]
        public bool LiberarUnidades(HorarioServicioEntity obj)
        {
            return service.LiberarUnidades(obj);
        }
    }
}
