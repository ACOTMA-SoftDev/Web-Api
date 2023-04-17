using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.EntityModels
{
    /// <summary>
    /// Clase que representa una entidad para la información de una publicación de mensajes con imágenes.
    /// </summary>
    public class MensajesImagenEntity
    {
        /// <summary>
        /// Identificador de la publicación.
        /// </summary>
        public int Id_Publicacion { get; set; }

        /// <summary>
        /// Fecha de la publicación.
        /// </summary>
        public DateTime Fecha_Pub { get; set; }

        /// <summary>
        /// Título de la publicación.
        /// </summary>
        public string Titulo_Pub { get; set; }

        /// <summary>
        /// Descripción de la publicación.
        /// </summary>
        public string Descripcion_Pub { get; set; }

        /// <summary>
        /// Imagen de la publicación en formato byte array.
        /// </summary>
        public byte[] ImagenP { get; set; }

        /// <summary>
        /// Usuario que realizó la publicación.
        /// </summary>
        public string usuario { get; set; }
    }
}
