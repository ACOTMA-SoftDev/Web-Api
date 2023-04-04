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
            

            return servicio.MostrarAccidentesDeHoy();
        }

        [HttpPost]
        [Route("api/Agregar_Informe_de_Accidente")]
        public bool agregarInformeAccidente(Informe_accidenteEntity nuevoAccidente)
        {            
            return servicio.agregarInformeAccidente(nuevoAccidente);
        }
        [HttpGet]
        [Route("api/ver_Registro_de_accidentes")]
        public List<Informe_Accidentes> InformeAccidente()
        {
            return servicio.GetAllAccidentesEntities();
        }

    }
}
