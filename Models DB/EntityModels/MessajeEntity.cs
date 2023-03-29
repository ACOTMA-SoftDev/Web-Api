using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.EntityModels
{
    public class MessajeEntity
    {
        public int Id_Publicacion { get; set; }
        public DateTime Fecha_Pub { get; set; }
        public string Titulo_Pub { get; set; }
        public string Descripcion_Pub { get; set; }
        public string ImagenP { get; set; }
        public string usuario { get; set; }
    }
}