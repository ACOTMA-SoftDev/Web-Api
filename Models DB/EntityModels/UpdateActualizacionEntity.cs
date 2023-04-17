using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acotma_API.Models_DB.EntityModels
{
    /// <summary>
    /// Clase que representa una entidad para actualizar información de asignación de unidades.
    /// </summary>
    public class UpdateActualizacionEntity
    {
        /// <summary>
        /// Número económico de la unidad.
        /// </summary>
        public int economico { get; set; }

        /// <summary>
        /// Número de tarjetón de la unidad.
        /// </summary>
        public int tarjeton { get; set; }

        /// <summary>
        /// Ruta asignada a la unidad.
        /// </summary>
        public string ruta { get; set; }

        /// <summary>
        /// Hora de acople asignada a la unidad.
        /// </summary>
        public string horaAcople { get; set; }

        /// <summary>
        /// Identificador de la asignación de la unidad.
        /// </summary>
        public int idAsignacion { get; set; }
    }
}
