using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acotma_API.Models_DB.EntityModels
{
    public class EliminarVerificacionEntity
    {
        public int corrida { get; set; } // Propiedad que representa el ID de la corrida a eliminar en la verificación
        public int idAsignacion { get; set; } // Propiedad que representa el ID de la asignación a eliminar en la verificación
    }
}
