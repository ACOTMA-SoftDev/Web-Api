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
    public class VerificacionAperturaController : ApiController
    {
        private readonly VerificadoresService service = new VerificadoresService(); // Servicio de verificadores

        // Método para obtener la lista de verificadores por idAsignacion
        [HttpGet]
        [Route("api/Verificacion/Servicio")]
        public List<GetServVerificadores> GetCheckid(int idAsignacion)
        {
            return service.GetServiceVerficadores(idAsignacion); // Retorna una lista de entidades de verificadores para la asignación con el idAsignacion especificado
        }

        // Método para obtener la lista completa de verificadores
        [HttpGet]
        [Route("api/Verificacion/Servicio/Completo")]
        public List<GetServVerificadores> GetCheck()
        {
            return service.GetServiceVerficadores(); // Retorna una lista de entidades de verificadores para todas las asignaciones
        }

        // Método para actualizar una verificación existente
        [HttpPost]
        public bool UpdateCheck(VerificacionSalidaEntity verificacion)
        {
            return service.UpdateVerificacion(verificacion); // Retorna true si la verificación se actualizó correctamente, false si no
        }

        // Método para agregar una nueva verificación
        [Route("api/addverificacion")]
        [HttpPost]
        public bool AgregarVerificacion(VerificacionSalidaEntity oVerificacion)
        {
            return service.AddVerificacion(oVerificacion); // Retorna true si la verificación se agregó correctamente, false si no
        }

        // Método para liberar unidades de una asignación
        [HttpPost]
        [Route("api/Liberar/Unidades")]
        public bool LiberarUnidades(HorarioServicioEntity obj)
        {
            return service.LiberarUnidades(obj); // Retorna true si se liberaron las unidades correctamente, false si no
        }

        // Método para eliminar una verificación existente
        [HttpPost]
        [Route("api/EliminarVerificacion")]
        public bool EliminarVerificadores(EliminarVerificacionEntity eliminarVerificacion)
        {
            return service.EliminarVerificacion(eliminarVerificacion); // Retorna true si la verificación se eliminó correctamente, false si no
        }

        // Método para actualizar una asignación de verificadores
        [HttpPost]
        [Route("api/Update/Verificacion")]
        public bool UpdateVerificacion(GetServVerificadores update)
        {
            return service.ActualizarAsignacion(update); // Retorna true si la asignación se actualizó correctamente, false si no
        }
    }
}
