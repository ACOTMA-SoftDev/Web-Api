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
    public class Informe_IncidenciasTecController : ApiController
    {
        Informe_IncidenciasTecService servicio = new Informe_IncidenciasTecService();

        [HttpGet]
        [Route("api/Informe_de_incidencias_tecnologicas_de_hoy")]
        public List<Informe_IncidenciasTecEntity> InformeIncTec()
        {
            return servicio.MostrarInformeIncidenciasTecDeHoy();
        }


        [HttpGet]
        [Route("api/Informes_de_Todas_incidencias_tecnologicas")]
        public List<Informe_IncidenciasTecEntity> InformeAllIncTec()
        {
            return servicio.GetAllInformeIncidenciasTecEntities();
        }


        [HttpPost]
        [Route("api/agregar_nueva_incidencia_tecnologica")]
        public bool agregarInformeIncTec(Informe_IncidenciasTecEntity nuevoInforme)
        {
            return servicio.agregarInformeIncTec(nuevoInforme);
        }

        [HttpPost]
        [Route("api/actualizarIncidenciaTecnologica")]

        public bool actualizarInforme(Informe_IncidenciasTecEntity updateInforme)
        {
            return servicio.actualizarInforme(updateInforme);
        }


        [HttpPost]
        [Route("api/eliminarIncidenciaTec")]

        public bool eliminarInformeTec(Informe_IncidenciasTecEntity deleteInformeTec)
        {
            return servicio.eliminarInformeTec(deleteInformeTec);
        }
    }
}
