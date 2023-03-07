using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acotma_API.Models_DB.EntityModels
{
    public class VerificacionSalidaEntity
    {
        public int idVerificacionSalida { get; set; }
        public string estado { get; set; }
        public string observaciones { get; set; }
        public TimeSpan fechaSalida { get; set; }
        public string fkusuario { get; set; }
        public int fkasignacion { get; set; }
    }
}