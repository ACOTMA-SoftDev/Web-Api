using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acotma_API.Models_DB.EntityModels
{
    /// <summary>
    /// Clase que representa una entidad para liberar unidades.
    /// </summary>
    public class LibrearUnidadesEntity
    {
        /// <summary>
        /// Corrida de la unidad.
        /// </summary>
        public int corrida { get; set; }

        /// <summary>
        /// Fecha de liberación de la unidad.
        /// </summary>
        public string fecha { get; set; }

        /// <summary>
        /// Hora de llegada de la unidad.
        /// </summary>
        public string horaLlegada { get; set; }
    }
}
