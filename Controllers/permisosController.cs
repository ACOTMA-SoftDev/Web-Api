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
    public class permisosController : ApiController
    {
        permisosService servicio = new permisosService();
        [HttpGet]

        public List<permisosEntity> InformeIncTec()
        {
            return servicio.GetPermisoEntities();
        }


        [HttpPost]
        public bool agregarPermiso(permisosEntity nuevoPermiso)
        {
            return servicio.agregarPermiso(nuevoPermiso);
        }

        [HttpPost]
        [Route("api/actualizarPermiso")]

        public bool actualizarPermiso(permisosEntity updatePermiso)
        {
            return servicio.actualizarPermiso(updatePermiso);
        }


        [HttpPost]
        [Route("api/eliminarPermiso")]

        public bool eliminarPermiso(permisosEntity deletePermiso)
        {
            return servicio.eliminarPermiso(deletePermiso);
        }
    }
}
