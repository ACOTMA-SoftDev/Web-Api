using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acotma_API.Models_DB.EntityModels
{
    public class verificacionDiaEntity
    {
        public int idVerificacionDia { get; set; }
        public Nullable<int> noUnidad { get; set; }
        public string observaciones { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public string fkUsuario { get; set; }
        public Nullable<int> fkEstado { get; set; }
    }
}