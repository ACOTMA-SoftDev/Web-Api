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
            // Este método HTTP de tipo GET recupera una lista de entidades de informe de incidencias tecnológicas para el día actual.
            // Retorna una lista de objetos de tipo Informe_IncidenciasTecEntity.
            // No tiene ningún parámetro de entrada.
            return servicio.MostrarInformeIncidenciasTecDeHoy();
        }

        [HttpGet]
        [Route("api/Informes_de_Todas_incidencias_tecnologicas")]
        public List<Informe_IncidenciasTecEntity> InformeAllIncTec()
        {
            // Este método HTTP de tipo GET recupera una lista de entidades de informe de todas las incidencias tecnológicas almacenadas.
            // Retorna una lista de objetos de tipo Informe_IncidenciasTecEntity.
            // No tiene ningún parámetro de entrada.
            return servicio.GetAllInformeIncidenciasTecEntities();
        }

        [HttpPost]
        [Route("api/agregar_nueva_incidencia_tecnologica")]
        public bool agregarInformeIncTec(Informe_IncidenciasTecEntity nuevoInforme)
        {
            // Este método HTTP de tipo POST agrega un nuevo informe de incidencia tecnológica.
            // Toma un parámetro de entrada de tipo Informe_IncidenciasTecEntity que contiene los datos del nuevo informe a agregar.
            // Retorna un valor booleano que indica si la operación de agregado fue exitosa o no.
            return servicio.agregarInformeIncTec(nuevoInforme);
        }

        [HttpPost]
        [Route("api/actualizarIncidenciaTecnologica")]
        public bool actualizarInforme(Informe_IncidenciasTecEntity updateInforme)
        {
            // Este método HTTP de tipo POST actualiza un informe de incidencia tecnológica existente.
            // Toma un parámetro de entrada de tipo Informe_IncidenciasTecEntity que contiene los datos del informe a actualizar.
            // Retorna un valor booleano que indica si la operación de actualización fue exitosa o no.
            return servicio.actualizarInforme(updateInforme);
        }

        [HttpPost]
        [Route("api/eliminarIncidenciaTec")]
        public bool eliminarInformeTec(Informe_IncidenciasTecEntity deleteInformeTec)
        {
            // Este método HTTP de tipo POST elimina un informe de incidencia tecnológica existente.
            // Toma un parámetro de entrada de tipo Informe_IncidenciasTecEntity que contiene los datos del informe a eliminar.
            // Retorna un valor booleano que indica si la operación de eliminación fue exitosa o no.
            return servicio.eliminarInformeTec(deleteInformeTec);
        }
    }
}
