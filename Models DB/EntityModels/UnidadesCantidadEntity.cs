using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acotma_API.Models_DB.EntityModels
{
    /// <summary>
    /// Clase que representa una entidad para la cantidad de unidades.
    /// </summary>
    public class UnidadesCantidadEntity
    {
        /// <summary>
        /// Tipo de unidad.
        /// </summary>
        public string tipoUnidad { get; set; }

        /// <summary>
        /// Cantidad de unidades del tipo especificado.
        /// </summary>
        public int cantidad { get; set; }

        /// <summary>
        /// Imagen de la unidad.
        /// </summary>
        public string ImagenUnidad { get; set; }
    }
}
