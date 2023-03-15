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
        [Authorize(Roles ="Verificador")]
        [HttpGet]
        public List<GetServVerificadores> GetCheck()
        {
            return service.GetServiceVerficadores();
        }
        [Authorize(Roles = "Verificador")]
        [HttpPost]
        public bool UpdateCheck(VerificacionSalidaEntity verificacion)
        {
            return service.UpdateVerificacion(verificacion);
        }
        [Authorize(Roles = "Verificador")]
        [Route ("api/addverificacion")]
        [HttpPost]
        public bool AgregarVerificacion(VerificacionSalidaEntity oVerificacion)
        {
            return service.AddVerificacion(oVerificacion);
        }
    }
}
