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
    public class CentroControlController : ApiController
    {
        CentroControlServices service = new CentroControlServices();
        [HttpGet]
        [Route("api/CentroControl/Asignaciones/Hoy")]
        public List<UnidadesCantidadEntity> UnidadCantidad()
        {
            return service.CantidadAsignacionHoy();
        }
        [HttpGet]
        [Route("api/CentroControl/Verificaciones/Hoy")]
        public string VerificacionesCantidad()
        {
            return service.CantidadVerificadaUnidades();
        }
    }
}
