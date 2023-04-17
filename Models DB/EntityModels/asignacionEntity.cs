using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acotma_API.Models_DB.EntityModels
{
    public class AsignacionEntity
    {
        public int idAsignacion { get; set; } // Propiedad que representa el ID de la asignación
        public string tipoUnidad { get; set; } // Propiedad que representa el tipo de unidad asignada
        public int economico { get; set; } // Propiedad que representa el número económico de la unidad asignada
        public int tarjeton { get; set; } // Propiedad que representa el número de tarjetón del chofer asignado
        public string nomChofer { get; set; } // Propiedad que representa el nombre del chofer asignado       
        public int fkCorrida { get; set; } // Propiedad que representa el ID de la corrida a la que se asigna la unidad
        public DateTime fkFecha { get; set; } // Propiedad que representa la fecha de la asignación
    }
}
