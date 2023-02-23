using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acotma_API.Models_DB.EntityModels
{
    public class verificacionSalidaEntity
    {
        public int idVerificacionSalida { get; set; }
        public string estado { get; set; }
        public string observaciones { get; set; }
        public Nullable<System.DateTime> fechaSalida { get; set; }
        public string fkusuario { get; set; }
    }
}