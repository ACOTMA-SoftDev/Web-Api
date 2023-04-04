using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acotma_API.Models_DB.EntityModels
{
    public class UpdateActualizacionEntity
    {
        public int economico { get; set; }
        public int tarjeton { get; set; }
        public string ruta { get; set; }
        public string horaAcople { get; set; }
        public int idAsignacion { get; set; }
    }
}