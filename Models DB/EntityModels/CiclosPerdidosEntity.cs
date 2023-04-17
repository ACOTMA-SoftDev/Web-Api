using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acotma_API.Models_DB.EntityModels
{
    public class CiclosPerdidosEntity
    {
        public int economico { get; set; } // Propiedad que representa el número económico de la unidad
        public string ruta { get; set; } // Propiedad que representa la ruta de la unidad
        public int corrida { get; set; } // Propiedad que representa la corrida de la unidad
        public string CiclosPerdidos { get; set; } // Propiedad que representa los ciclos perdidos de la unidad
        public string observaciones { get; set; } // Propiedad que representa las observaciones de los ciclos perdidos de la unidad
    }
}
