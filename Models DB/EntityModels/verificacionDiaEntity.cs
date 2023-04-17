using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acotma_API.Models_DB.EntityModels
{
    /// <summary>
    /// Clase que representa una entidad de verificación de día.
    /// </summary>
    public class VerificacionDiaEntity
    {
        /// <summary>
        /// Identificador de verificación de día.
        /// </summary>
        public int idVerificacionDia { get; set; }

        /// <summary>
        /// Tipo de unidad verificada.
        /// </summary>
        public string tipoUnidad { get; set; }

        /// <summary>
        /// Número económico de la unidad verificada.
        /// </summary>
        public int economico { get; set; }

        /// <summary>
        /// Número de tarjetón de la unidad verificada.
        /// </summary>
        public int noTarjeton { get; set; }

        /// <summary>
        /// Ruta de la unidad verificada.
        /// </summary>
        public string ruta { get; set; }

        /// <summary>
        /// Observaciones de la verificación de día.
        /// </summary>
        public string observaciones { get; set; }

        /// <summary>
        /// Fecha de la verificación de día.
        /// </summary>
        public DateTime fecha { get; set; }

        /// <summary>
        /// Usuario que realizó la verificación de día.
        /// </summary>
        public string fkUsuario { get; set; }
    }
}
