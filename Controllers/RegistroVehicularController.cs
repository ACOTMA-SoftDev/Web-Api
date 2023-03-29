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
    public class RegistroVehicularController : ApiController
    {
        RegistroVehicularService servicio = new RegistroVehicularService();
        [HttpGet]
        [Route("api/ver_Registro_de_Asignacion_de_Radios")]
        public List<RegistroVehicularEntity> Asignar_Radios()
        {
            return servicio.GetAsignacionVehicularEntities();
        }


        [HttpPost]
        [Route("api/agregar_Asignacion_de_Radios")]
        public bool agregarAsignacion(RegistroVehicularEntity nuevoRegistro)
        {
            return servicio.agregarAsignacionVehicular(nuevoRegistro);
        }
    }
}
