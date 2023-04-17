using Acotma_API.Models_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebApplication2.Models.EntityModels;
using WebApplication2.Service;

namespace WebApplication2.Controllers
{
    public class Informe_accidenteController : ApiController
    {
        Informe_accidentesService servicio = new Informe_accidentesService();

        [HttpGet]
        [Route("api/Informe_de_Accidente_de_hoy")]
        public List<Informe_accidenteEntity> InformeAccidenteHoy()
        {
            // Este método HTTP de tipo GET recupera una lista de entidades de informe de accidentes para el día actual.
            // Retorna una lista de objetos de tipo Informe_accidenteEntity.
            // No tiene ningún parámetro de entrada.
            return servicio.MostrarAccidentesDeHoy();
        }

        [HttpPost]
        [Route("api/Agregar_Informe_de_Accidente")]
        public bool agregarInformeAccidente(Informe_accidenteEntity nuevoAccidente)
        {
            // Este método HTTP de tipo POST agrega un nuevo informe de accidente.
            // Toma un parámetro de entrada de tipo Informe_accidenteEntity que contiene los datos del nuevo accidente a agregar.
            // Retorna un valor booleano que indica si la operación de agregado fue exitosa o no.
            return servicio.agregarInformeAccidente(nuevoAccidente);
        }

        [HttpGet]
        [Route("api/ver_Registro_de_accidentes")]
        public List<Informe_Accidentes> InformeAccidente()
        {
            // Este método HTTP de tipo GET recupera una lista de objetos de tipo Informe_Accidentes que representan todos los registros de accidentes almacenados.
            // Retorna una lista de objetos de tipo Informe_Accidentes.
            // No tiene ningún parámetro de entrada.
            return servicio.GetAllAccidentesEntities();
        }
    }
}
