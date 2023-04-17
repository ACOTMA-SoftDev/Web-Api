using System;  // Importa el espacio de nombres System, que contiene clases fundamentales del lenguaje C# y del Framework .NET.
using System.Collections.Generic;  // Importa el espacio de nombres System.Collections.Generic, que contiene clases para manejar colecciones genéricas.
using System.Linq;  // Importa el espacio de nombres System.Linq, que contiene clases para realizar consultas en colecciones.
using System.Net;  // Importa el espacio de nombres System.Net, que contiene clases para la comunicación en red.
using System.Net.Http;  // Importa el espacio de nombres System.Net.Http, que contiene clases para trabajar con HTTP.
using System.Web.Http;  // Importa el espacio de nombres System.Web.Http, que contiene clases para la creación de APIs Web en ASP.NET.
using WebApplication2.Models.EntityModels;  // Importa el espacio de nombres WebApplication2.Models.EntityModels, que contiene las clases de modelos de entidades utilizadas en la API.
using WebApplication2.Service;  // Importa el espacio de nombres WebApplication2.Service, que contiene las clases de servicio utilizadas en la API.

namespace WebApplication2.Controllers
{
    public class Asignacion_RadiosController : ApiController
    {
        Asignar_RadiosService servicio = new Asignar_RadiosService();  // Crea una instancia del servicio Asignar_RadiosService para manejar las operaciones de la API.

        [HttpGet]
        [Route("api/ver_Registro_de_Asignacion_de_Radios")]
        public List<Asignar_RadiosEntity> Asignar_Radios()
        {
            return servicio.GetAsignacionRadiosEntities();  // Define una acción HTTP GET con la ruta "api/ver_Registro_de_Asignacion_de_Radios" que llama al método GetAsignacionRadiosEntities() del servicio para obtener una lista de entidades Asignar_RadiosEntity.
        }

        [HttpPost]
        [Route("api/agregar_Asignacion_de_Radios")]
        public bool agregarAsignacion(Asignar_RadiosEntity nuevaAsignacion)
        {
            return servicio.agregarAsignacion(nuevaAsignacion);  // Define una acción HTTP POST con la ruta "api/agregar_Asignacion_de_Radios" que llama al método agregarAsignacion() del servicio para agregar una nueva asignación de radios.
        }

        [HttpPost]
        [Route("api/actualizar_Asignacion_de_Radios")]
        public bool actualizarAsignacion(Asignar_RadiosEntity updateAsignacion)
        {
            return servicio.actualizarAsignacion(updateAsignacion);  // Define una acción HTTP POST con la ruta "api/actualizar_Asignacion_de_Radios" que llama al método actualizarAsignacion() del servicio para actualizar una asignación de radios existente.
        }

        [HttpPost]
        [Route("api/eliminar_Asignacion_de_Radios")]
        public bool eliminarAsignacion(Asignar_RadiosEntity deleteAsignacion)
        {
            return servicio.eliminarAsignacion(deleteAsignacion);  // Define una acción HTTP POST con la ruta "api/eliminar_Asignacion_de_Radios" que llama al método eliminarAsignacion() del servicio para eliminar una asignación de radios existente.
        }
    }
}
