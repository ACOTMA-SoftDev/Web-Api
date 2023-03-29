using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.EntityModels
{
    public class Asignar_RadiosEntity
    {
        public int Id_asignacionRadio { get; set; }
        public string usuario { get; set; }
        public int Num_Radio { get; set; }
        public string Codigo_Radio { get; set; }
        public string Tarjeta_Maestra { get; set; }
    }
}