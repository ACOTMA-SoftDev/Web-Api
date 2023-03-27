using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acotma_API.Models_DB.EntityModels
{
    public class GetServVerificadores
    {
        public int idAsignacion { get; set; }
        public string tipoUnidad { get; set; }
        public string ruta { get; set; }
        public int economico { get; set; }
        public int tarjeton { get; set; }
        public string nomChofer { get; set; }
        public int corrida { get; set; }
        public TimeSpan horarioSalida { get; set; }
        public TimeSpan horarioLlegada { get; set; }
        public DateTime fecha { get; set; }
    }    
}