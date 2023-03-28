using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acotma_API.Models_DB.EntityModels
{
    public class CronosListVerificacionEntity
    {
        public int idAsignacion { get; set; }
        public string tipoUnidad { get; set; }
        public int economico { get; set; }
        public int tarjeton { get; set; }
        public string nomChofer { get; set; }
        public int fkCorrida { get; set; }
        public int fkFecha { get; set; }
        public int corrida { get; set; }
        public string fecha { get; set; }
        public string ruta { get; set; }
        public string horarioSalida { get; set; }
        public string horaLlegada { get; set; }
        public int idVerificacionSalida { get; set; }
        public string estado { get; set; }
        public string observaciones { get; set; }
        public string horaSalida { get; set; }
        public string fkusuario { get; set; }
        public int fkAsignacion { get; set; }

    }
}