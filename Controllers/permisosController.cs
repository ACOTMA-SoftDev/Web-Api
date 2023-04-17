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
        permisosService servicio = new permisosService(); // Servicio de permisos

        // Método para obtener la lista de permisos
        [HttpGet]
        public List<permisosEntity> InformeIncTec()
        {
            return servicio.GetPermisoEntities(); // Retorna una lista de permisos
        }

        // Método para agregar un nuevo permiso
        [HttpPost]
        public bool agregarPermiso(permisosEntity nuevoPermiso)
        {
            return servicio.agregarPermiso(nuevoPermiso); // Retorna true si el permiso se agregó correctamente, false si no
        }

        // Método para actualizar un permiso existente
        [HttpPost]
        [Route("api/actualizarPermiso")]
        public bool actualizarPermiso(permisosEntity updatePermiso)
        {
            return servicio.actualizarPermiso(updatePermiso); // Retorna true si el permiso se actualizó correctamente, false si no
        }

        // Método para eliminar un permiso existente
        [HttpPost]
        [Route("api/eliminarPermiso")]
        public bool eliminarPermiso(permisosEntity deletePermiso)
        {
            return servicio.eliminarPermiso(deletePermiso); // Retorna true si el permiso se eliminó correctamente, false si no
        }
    }
}
