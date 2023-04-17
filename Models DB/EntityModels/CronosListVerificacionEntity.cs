using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acotma_API.Models_DB.EntityModels
{
    public class CronosListVerificacionEntity
    {
        public int idAsignacion { get; set; } // Propiedad que representa el ID de asignación
        public string tipoUnidad { get; set; } // Propiedad que representa el tipo de unidad
        public int economico { get; set; } // Propiedad que representa el número económico de la unidad
        public int tarjeton { get; set; } // Propiedad que representa el tarjetón de la unidad
        public string nomChofer { get; set; } // Propiedad que representa el nombre del chofer
        public int fkCorrida { get; set; } // Propiedad que representa el ID de la corrida
        public DateTime fkFecha { get; set; } // Propiedad que representa la fecha de la corrida
        public int corrida { get; set; } // Propiedad que representa la corrida de la unidad
        public DateTime fecha { get; set; } // Propiedad que representa la fecha
        public string ruta { get; set; } // Propiedad que representa la ruta de la unidad
        public TimeSpan horarioSalida { get; set; } // Propiedad que representa el horario de salida
        public TimeSpan horaLlegada { get; set; } // Propiedad que representa la hora de llegada
        public int idVerificacionSalida { get; set; } // Propiedad que representa el ID de verificación de salida
        public string estado { get; set; } // Propiedad que representa el estado
        public string observaciones { get; set; } // Propiedad que representa las observaciones
        public TimeSpan horaSalida { get; set; } // Propiedad que representa la hora de salida
        public string fkusuario { get; set; } // Propiedad que representa el ID de usuario
        public int fkAsignacion { get; set; } // Propiedad que representa el ID de asignación

    }
}
