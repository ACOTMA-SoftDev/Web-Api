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
        Messaje_PubService service = new Messaje_PubService(); // Servicio de publicaciones

        // Método para obtener las publicaciones de hoy
        [HttpGet]
        [Route("api/Publicaciones")]
        public List<MessajeEntity> Messajes()
        {
            return service.MostrarPublicacionesDeHoy(); // Retorna una lista de publicaciones de hoy
        }

        // Método para obtener las publicaciones recibidas de hoy
        [HttpGet]
        [Route("api/PublicacionesParaTitanes")]
        public List<MessajeEntity> MessajesRecividos()
        {
            return service.MostrarPublicacionesDeHoy(); // Retorna una lista de publicaciones de hoy
        }

        // Método para agregar una nueva publicación
        [HttpPost]
        [Route("api/agregarPublicaciones")]
        public bool agregarPublicacion(MessajeEntity nuevaPublicacion)
        {
            return service.agregarPublicacion(nuevaPublicacion); // Retorna true si la publicación se agregó correctamente, false si no
        }

    }
}
