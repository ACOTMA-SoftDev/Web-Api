using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acotma_API.Models_DB.EntityModels
{
    /// <summary>
    /// Clase que representa una entidad para servicios iniciados.
    /// </summary>
    public class ServiciosIniciadosEntity
    {
        /// <summary>
        /// ID de la asignación del servicio.
        /// </summary>
        public int idAsignacion { get; set; }

        /// <summary>
        /// Tipo de unidad del servicio.
        /// </summary>
        public string tipoUnidad { get; set; }

        /// <summary>
        /// Número económico de la unidad del servicio.
        /// </summary>
        public int economico { get; set; }

        /// <summary>
        /// Número de tarjetón del chofer del servicio.
        /// </summary>
        public int tarjeton { get; set; }

        /// <summary>
        /// Nombre del chofer del servicio.
        /// </summary>
        public string nomChofer { get; set; }

        /// <summary>
        /// ID de la corrida asociada al servicio.
        /// </summary>
        public int fkCorrida { get; set; }

        /// <summary>
        /// Fecha de la corrida asociada al servicio.
        /// </summary>
        public DateTime fkFecha { get; set; }

        /// <summary>
        /// Número de corrida del servicio.
        /// </summary>
        public int corrida { get; set; }

        /// <summary>
        /// Fecha del servicio.
        /// </summary>
        public DateTime fecha { get; set; }

        /// <summary>
        /// Ruta del servicio.
        /// </summary>
        public string ruta { get; set; }

        /// <summary>
        /// Horario de salida del servicio.
        /// </summary>
        public TimeSpan horarioSalida { get; set; }

        /// <summary>
        /// Hora de llegada del servicio.
        /// </summary>
        public TimeSpan horaLlegada { get; set; }
    }
}
