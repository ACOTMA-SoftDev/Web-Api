using Acotma_API.Models_DB;
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
    public class VerificacionDiaController : ApiController
    {
        // Crear una instancia del servicio VerificacionDiaService
        readonly VerificacionDiaService service = new VerificacionDiaService();

        // Método HTTP POST para actualizar la verificación del día
        [HttpPost]
        public bool UpdateServApert(VerificacionDiaEntity verificacion)
        {
            // Llamar al método UpdateVerificacionDia del servicio VerificacionDiaService y pasarle la entidad de verificación como parámetro
            return service.UpdateVerificacionDia(verificacion);
        }

        // Decorador de ruta para especificar la ruta de la API para el método InsertarVerificacionDay
        [Route("api/InsertarVerificacionDay")]
        [HttpPost]
        // Método HTTP POST para insertar una nueva verificación del día
        public bool InsertarVerificacionDay(VerificacionDiaEntity newVerificacion)
        {
            // Llamar al método InsertarVerificacionDay del servicio VerificacionDiaService y pasarle la entidad de verificación como parámetro
            return service.InsertarVerificacionDay(newVerificacion);
        }
    }
}
