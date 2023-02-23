using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acotma_API.Models_DB.EntityModels
{
    public class asignacionEntity
    {
        public int idAsignacion { get; set; }
        public string tipoUnidad { get; set; }
        public int economico { get; set; }
        public int tarjeton { get; set; }
        public string nomChofer { get; set; }
        public int fkVerificacionSalida { get; set; }
        public int fkCorrida { get; set; }
        public DateTime fkFecha { get; set; }
    }
}