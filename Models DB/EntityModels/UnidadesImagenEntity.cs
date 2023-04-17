using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acotma_API.Models_DB.EntityModels
{
    /// <summary>
    /// Clase que representa una entidad para enviar imágenes de unidades.
    /// </summary>
    public class UnidadesImagenEntitySendImage
    {
        /// <summary>
        /// Identificador de la imagen de la unidad.
        /// </summary>
        public string idUnidadesIcon { get; set; }

        /// <summary>
        /// Nombre de la unidad.
        /// </summary>
        public string NombreUnidad { get; set; }

        /// <summary>
        /// Imagen de la unidad en formato base64.
        /// </summary>
        public string ImagenUnidad { get; set; }
    }
}
