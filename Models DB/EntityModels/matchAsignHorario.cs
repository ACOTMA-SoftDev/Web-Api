using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acotma_API.Models_DB.EntityModels
{
    /// <summary>
    /// Clase que representa una entidad para el emparejamiento de asignación de horarios.
    /// </summary>
    public class MatchAsignHorario
    {
        /// <summary>
        /// Identificador de la asignación.
        /// </summary>
        public int idAsignacion { get; set; }

        /// <summary>
        /// Tipo de unidad.
        /// </summary>
        public string tipoUnidad { get; set; }

        /// <summary>
        /// Número económico de la unidad.
        /// </summary>
        public int economico { get; set; }

        /// <summary>
        /// Número de tarjetón del chofer.
        /// </summary>
        public int tarjeton { get; set; }

        /// <summary>
        /// Nombre del chofer.
        /// </summary>
        public string nomChofer { get; set; }

        /// <summary>
        /// Identificador de la corrida.
        /// </summary>
        public int fkCorrida { get; set; }

        /// <summary>
        /// Fecha de la corrida.
        /// </summary>
        public DateTime fkFecha { get; set; }

        /// <summary>
        /// Corrida de la unidad.
        /// </summary>
        public int corrida { get; set; }

        /// <summary>
        /// Fecha de liberación de la unidad.
        /// </summary>
        public DateTime fecha { get; set; }

        /// <summary>
        /// Ruta asignada a la unidad.
        /// </summary>
        public string ruta { get; set; }
    }
}
