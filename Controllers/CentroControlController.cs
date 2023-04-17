using Acotma_API.Models_DB.EntityModels;
using Acotma_API.ServiciosModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Acotma_API.Controllers
{
    public class CentroControlController : ApiController
    {
        CentroControlServices service = new CentroControlServices();

        // Obtener la cantidad de asignaciones para hoy
        [HttpGet]
        [Route("api/CentroControl/Asignaciones/Hoy")]
        public List<UnidadesCantidadEntity> UnidadCantidad()
        {
            return service.CantidadAsignacionHoy();
        }

        // Obtener la cantidad de verificaciones para hoy
        [HttpGet]
        [Route("api/CentroControl/Verificaciones/Hoy")]
        public List<UnidadesCantidadLiberadoEntity> VerificacionesCantidad()
        {
            return service.CantidadVerificadaUnidades();
        }

        // Obtener la lista de unidades liberadas en las verificaciones
        [HttpGet]
        [Route("api/CentroControl/Verificacion/Liberado")]
        public List<CronosListVerificacionEntity> VerificacionResult()
        {
            return service.ListLiberados();
        }

        // Agregar una imagen de unidad en la verificación
        [HttpPost]
        [Route("api/CentroControl/Verificacion/ImagenUnidades")]
        public bool AddImagenUnidad(UnidadesImagenEntitySendImage unidades)
        {
            return service.insertarImagen(unidades);
        }

        // Obtener la cantidad de imágenes de unidades en la verificación
        [HttpGet]
        [Route("api/CentroControl/Verificacion/GetImagenesUnidades")]
        public List<UnidadesCantidadEntity> GetImagenesUnidad()
        {
            return service.GetImagenUnidadCantidad();
        }

        // Obtener la lista de ciclos perdidos
        [HttpGet]
        [Route("api/CentroControl/GetCiclos")]
        public List<CiclosPerdidosEntity> GetCiclosPerdidos()
        {
            return service.GetCiclosPerdidos();
        }
    }
}
