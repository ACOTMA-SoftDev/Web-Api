using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acotma_API.Models_DB.EntityModels
{
    public class eliminarHorarioServicio
    {
        public DateTime fechaDelete { get; set; } // Propiedad que representa la fecha del horario de servicio a eliminar
        public string rutaDelete { get; set; } // Propiedad que representa la ruta del horario de servicio a eliminar
    }
}
