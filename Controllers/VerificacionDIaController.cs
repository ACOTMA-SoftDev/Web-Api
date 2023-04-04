using Acotma_API.Models_DB;
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
    public class VerificacionDiaController : ApiController
    {
        readonly VerificacionDiaService service = new VerificacionDiaService();        
        [HttpPost]
        public bool UpdateServApert(VerificacionDiaEntity verificacion)
        {
            return service.UpdateVerificacionDia(verificacion);
        }        
        [Route ("api/InsertarVerificacionDay")]
        [HttpPost]
        public bool InsertarVerificacionDay (VerificacionDiaEntity newVerificacion)
        {
            return service.InsertarVerificacionDay(newVerificacion);
        }
        
    }
}
