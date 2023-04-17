using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acotma_API.Models_DB.EntityModels
{
    /// <summary>
    /// Clase que representa una entidad para seleccionar información por ID, fecha y corrida.
    /// </summary>
    public class SelectIdFecha
    {
        /// <summary>
        /// Ruta seleccionada.
        /// </summary>
        public string ruta { get; set; }

        /// <summary>
        /// Fecha seleccionada.
        /// </summary>
        public DateTime fecha { get; set; }

        /// <summary>
        /// Corrida seleccionada.
        /// </summary>
        public int corrida { get; set; }
    }
}
