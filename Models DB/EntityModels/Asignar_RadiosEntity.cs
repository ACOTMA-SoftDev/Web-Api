using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.EntityModels
{
    public class Asignar_RadiosEntity
    {
        public int Id_asignacionRadio { get; set; } // Propiedad que representa el ID de la asignación de radio
        public string usuario { get; set; } // Propiedad que representa el usuario asignado al radio
        public int Num_Radio { get; set; } // Propiedad que representa el número del radio asignado
        public string Codigo_Radio { get; set; } // Propiedad que representa el código del radio asignado
        public string Tarjeta_Maestra { get; set; } // Propiedad que representa la tarjeta maestra asignada
    }
}
