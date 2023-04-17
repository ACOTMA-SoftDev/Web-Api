using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acotma_API.Models_DB.EntityModels
{
    public class HorarioServicioEntity
    {
        public int corrida { get; set; } // Propiedad que representa el número de corrida en el horario de servicio
        public System.DateTime fecha { get; set; } // Propiedad que representa la fecha en el horario de servicio
        public string ruta { get; set; } // Propiedad que representa la ruta en el horario de servicio
        public TimeSpan horarioSalida { get; set; } // Propiedad que representa el horario de salida en el horario de servicio
        public TimeSpan horaLlegada { get; set; } // Propiedad que representa el horario de llegada en el horario de servicio
    }
}
