﻿using System;
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
        [Route("api/ver_Registro_Vehicular")]
        public List<RegistroVehicularEntity> VerRegistro()
        {
            return servicio.GetAsignacionVehicularEntities();
        }


        [HttpPost]
        [Route("api/agregar_RegistroVehicular")]
        public bool agregarAsignacionVehicular(RegistroVehicularEntity nuevoRegistro)
        {
            return servicio.agregarAsignacionVehicular(nuevoRegistro);
        }
    }
}
