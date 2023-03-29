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
    public class Informe_LimpiezaController : ApiController
    {

        Informe_LimpiezaService service = new Informe_LimpiezaService();

        //MUESTRA EL INFORME DE LIMPIEZA DE TODOS LOS DIAS DE TODAS LAS ESTACIONES
        [HttpGet]
        [Route("api/resumen_limpieza")]
        public List<Informe_LimpiezaEntity> Informe_Limpieza()
        {
            return service.GetInformeLimpiezaEntities();
        }

        //MUESTRA TODOS LOS INFORMES DE LIMPIEZA DE HOY DE TODAS LAS ESTACIONES
        [HttpGet]
        [Route("api/limpieza_del_dia_de_hoy")]
        public List<Informe_LimpiezaEntity> Informe_Limpieza_today()
        {
            return service.MostrarInformeLimpiezaDeHoy();
        }

        [HttpPost]
        [Route("api/agregar_informeLimpieza_del_dia_hoy")]
        public bool agregarInformeLimpieza(Informe_LimpiezaEntity nuevoInformeLimpieza)
        {
            return service.agregarInformeLimpieza(nuevoInformeLimpieza);
        }
    }
}