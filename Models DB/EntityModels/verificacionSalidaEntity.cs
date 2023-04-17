using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acotma_API.Models_DB.EntityModels
{
    /// <summary>
    /// Clase que representa una entidad de verificación de salida.
    /// </summary>
    public class VerificacionSalidaEntity
    {
        /// <summary>
        /// Identificador de verificación de salida.
        /// </summary>
        public int IdVerificacionSalida { get; set; }

        /// <summary>
        /// Estado de la verificación de salida.
        /// </summary>
        public string Estado { get; set; }

        /// <summary>
        /// Observaciones de la verificación de salida.
        /// </summary>
        public string Observaciones { get; set; }

        /// <summary>
        /// Ciclos perdidos en la verificación de salida.
        /// </summary>
        public string ciclosPerdidos { get; set; }

        /// <summary>
        /// Hora de salida en la verificación de salida.
        /// </summary>
        public TimeSpan HoraSalida { get; set; }

        /// <summary>
        /// Usuario que realizó la verificación de salida.
        /// </summary>
        public string Fkusuario { get; set; }

        /// <summary>
        /// Asignación relacionada con la verificación de salida.
        /// </summary>
        public int Fkasignacion { get; set; }
    }
}
