using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.EntityModels
{
    public class Informe_LimpiezaEntity
    {
        public int IdInformeLimpieza { get; set; }
        public DateTime Fecha_Limpieza { get; set; }
        public string Estacion { get; set; }
        public string LimpiezaPiso { get; set; }
        public string LimpiezaVidrio { get; set; }
        public string LimpiezaAreaServicios { get; set; }
        public string LimpiezaAreaEstructura { get; set; }
        public string LimpiezaTorniquetes { get; set; }
        public string LimpiezaSanitarios { get; set; }
        public string Observaciones { get; set; }
        public string usuario { get; set; }
    }
}