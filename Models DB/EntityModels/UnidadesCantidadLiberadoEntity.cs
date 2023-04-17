using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acotma_API.Models_DB.EntityModels
{
    /// <summary>
    /// Clase que representa una entidad para la cantidad de unidades liberadas.
    /// </summary>
    public class UnidadesCantidadLiberadoEntity
    {
        /// <summary>
        /// Tipo de unidad.
        /// </summary>
        public string tipoUnidad { get; set; }

        /// <summary>
        /// Cantidad de unidades liberadas del tipo especificado.
        /// </summary>
        public int cantidadLiberado { get; set; }

        /// <summary>
        /// Imagen de la unidad.
        /// </summary>
        public string ImagenUnidad { get; set; }
    }
}
