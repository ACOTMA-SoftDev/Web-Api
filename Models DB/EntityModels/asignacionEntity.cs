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
        public Nullable<int> economico { get; set; }
        public Nullable<int> tarjeton { get; set; }
        public string nomChofer { get; set; }
        public Nullable<int> fkVerificacionSalida { get; set; }
        public Nullable<int> fkCorrida { get; set; }
        public Nullable<System.DateTime> fkFecha { get; set; }
    }
}