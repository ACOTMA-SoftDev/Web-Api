using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acotma_API.Models_DB.EntityModels
{
    public class GetServVerificadores
    {
        public int idAsignacion { get; set; } // Propiedad que representa el ID de la asignación en el servicio de verificación
        public string tipoUnidad { get; set; } // Propiedad que representa el tipo de unidad en el servicio de verificación
        public string ruta { get; set; } // Propiedad que representa la ruta en el servicio de verificación
        public int economico { get; set; } // Propiedad que representa el número económico en el servicio de verificación
        public int tarjeton { get; set; } // Propiedad que representa el número de tarjetón en el servicio de verificación
        public string nomChofer { get; set; } // Propiedad que representa el nombre del chofer en el servicio de verificación
        public int corrida { get; set; } // Propiedad que representa el número de corrida en el servicio de verificación
        public TimeSpan horarioSalida { get; set; } // Propiedad que representa el horario de salida en el servicio de verificación
        public TimeSpan horarioLlegada { get; set; } // Propiedad que representa el horario de llegada en el servicio de verificación
        public DateTime fecha { get; set; } // Propiedad que representa la fecha en el servicio de verificación
    }
}
