using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.EntityModels
{
    public class RegistroVehicularEntity
    {
        public int Id_RegistroVeh { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombre_solicitante { get; set; }
        public string Marca_vehiculo { get; set; }
        public string Submarca { get; set; }
        public string Placa { get; set; }
        public string Tiempo { get; set; }
        public string Area_solicitante { get; set; }
        public string Actividades_a_realizar { get; set; }
        public string Registro_de_kilometraje { get; set; }
    }
}