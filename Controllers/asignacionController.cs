using Acotma_API.Models_DB;
using Acotma_API.Models_DB.EntityModels;
using Acotma_API.serviciosModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Acotma_API.Controllers
{
    public class AsignacionController : ApiController
    {
        readonly AsignacionServicio service = new AsignacionServicio();
        readonly HorarioServicioService hServ = new HorarioServicioService();

        // Método HTTP POST para agregar un servicio
        [HttpPost]
        [Route("api/Agregar/Servicio")]
        public bool AgregarServicio(List<AsignacionEntity> oService)
        {
            bool response = false;
            try
            {
                for (int i = 0; i < oService.Count; i++)
                {
                    // Verificar si existe un horario para la corrida hoy
                    List<HorarioServicioEntity> horario = hServ.GetCorridaToday(oService[i].fkCorrida);
                    if (horario.Count > 0)
                    {
                        service.AddAsignacion(oService[i]);
                        response = true;
                    }
                }

            }
            catch (Exception e)
            {
                string ex = e.Message;
                Console.WriteLine(ex);
            }
            return response;
        }

        // Método HTTP POST para actualizar una asignación
        [Route("api/UpdateAsignacion")]
        [HttpPost]
        public bool UpdateAsigancion(AsignacionEntity uAsignacion)
        {
            return service.UpdateAsignacion(uAsignacion);
        }

        // Método HTTP GET para obtener las asignaciones para una fecha específica
        [HttpGet]
        public List<MatchAsignHorario> Asignaciones(string fkFecha)
        {
            DateTime f = DateTime.Parse(fkFecha);
            var lista = service.AsignHorarios(f);
            return lista.ToList();
        }

        // Método HTTP GET para obtener las asignaciones del día actual
        [Route("api/consultarAsignacionDay")]
        [HttpGet]
        public List<AsignacionEntity> GetAsignacionDay()
        {
            return service.ConsultarAsignacionDay();
        }

        // Método HTTP GET para obtener los servicios iniciados
        [HttpGet]
        [Route("api/ServiciosIniciados")]
        public List<ServiciosIniciadosEntity> GetServiciosIniciados()
        {
            return service.GetServiciosIniciados();
        }

        // Método HTTP GET para obtener los servicios iniciados por ID de asignación
        [HttpGet]
        [Route("api/ServiciosIniciadosById")]
        public List<ServiciosIniciadosEntity> GetServiciosById(int idAsignacion)
        {
            return service.GetServiciosIniciadosById(idAsignacion);
        }

        // Método HTTP GET para eliminar las asignaciones del día actual
        [HttpGet]
        [Route("api/Delete/Asignacion")]
        public bool DeleteResponseAsignacion()
        {
            return service.DeleteAsignacionToday();
        }
    }
}
