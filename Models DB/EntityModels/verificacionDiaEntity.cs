using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acotma_API.Models_DB.EntityModels
{
    public class VerificacionDiaEntity
    {
        public int idVerificacionDia { get; set; }
        public string tipoUnidad { get; set; }
        public int economico { get; set; }
        public int noTarjeton { get; set; }
        public string ruta { get; set; }
        public string observaciones { get; set; }
        public DateTime fecha { get; set; }
        public string fkUsuario { get; set; }
    }
}