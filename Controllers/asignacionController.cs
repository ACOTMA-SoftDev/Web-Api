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
    public class asignacionController : ApiController
    {
        asignacionServicio serviceAsigna = new asignacionServicio();

        [HttpPost]

        public bool updateAsigancion(asignacionEntity uAsignacion)
        {
            return serviceAsigna.UpdateAsignacion(uAsignacion);
        }
    }
}
