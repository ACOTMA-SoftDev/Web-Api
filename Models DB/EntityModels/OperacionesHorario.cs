using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acotma_API.Models_DB.EntityModels
{
    /// <summary>
    /// Clase que representa una entidad para la información de operaciones de horarios.
    /// </summary>
    public class OperacionesHorario
    {
        /// <summary>
        /// Ruta de la operación de horario.
        /// </summary>
        public string ruta { get; set; }

        /// <summary>
        /// Corrida inicial de la operación de horario.
        /// </summary>
        public int corridaInicial { get; set; }

        /// <summary>
        /// Corrida final de la operación de horario.
        /// </summary>
        public int corridaFinal { get; set; }

        /// <summary>
        /// Intervalo de la operación de horario.
        /// </summary>
        public int intervalo { get; set; }

        /// <summary>
        /// Fecha de inicio de la operación de horario.
        /// </summary>
        public string fechaInicio { get; set; }

        /// <summary>
        /// Fecha final de la operación de horario.
        /// </summary>
        public string fechaFinal { get; set; }

        /// <summary>
        /// Hora de la primera salida de la operación de horario.
        /// </summary>
        public TimeSpan primeraSalida { get; set; }
    }
}
