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
    public class Asignacion_RadiosController : ApiController
    {
        Asignar_RadiosService servicio = new Asignar_RadiosService();
        [HttpGet]
        [Route("api/ver_Registro_de_Asignacion_de_Radios")]
        public List<Asignar_RadiosEntity> Asignar_Radios()
        {
            return servicio.GetAsignacionRadiosEntities();
        }


        [HttpPost]
        [Route("api/agregar_Asignacion_de_Radios")]
        public bool agregarAsignacion(Asignar_RadiosEntity nuevaAsignacion)
        {
            return servicio.agregarAsignacion(nuevaAsignacion);
        }

        [HttpPost]
        [Route("api/actualizar_Asignacion_de_Radios")]

        public bool actualizarAsignacion(Asignar_RadiosEntity updateAsignacion)
        {
            return servicio.actualizarAsignacion(updateAsignacion);
        }


        [HttpPost]
        [Route("api/eliminar_Asignacion_de_Radios")]

        public bool eliminarAsignacion(Asignar_RadiosEntity deleteAsignacion)
        {
            return servicio.eliminarAsignacion(deleteAsignacion);
        }
    }
}
