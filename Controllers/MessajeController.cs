using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Models.EntityModels;
using WebApplication2.Service;

namespace WebApplication2.Controllers
{
    public class MessajeController : ApiController
    {
        Messaje_PubService service = new Messaje_PubService();

        [HttpGet]
        [Route("api/Publicaciones")]
        public List<MessajeEntity> Messajes()
        {
            return service.MostrarPublicacionesDeHoy();
        }


        [HttpGet]
        [Route("api/PublicacionesParaTitanes")]
        public List<MessajeEntity> MessajesRecividos()
        {
            return service.MostrarPublicacionesDeHoy();
        }


        [HttpPost]

        [Route("api/agregarPublicaciones")]
        public bool agregarPublicacion(MessajeEntity nuevaPublicacion)
        {
            return service.agregarPublicacion(nuevaPublicacion);
        }

    }
}
