using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.EntityModels
{
    public class Informe_accidenteEntity
    {
        public int Id_Percance { get; set; }
        public DateTime Fecha_Percance { get; set; }
        public int NoEconomico { get; set; }
        public string ServicioRuta { get; set; }
        public string TipoUnidad { get; set; }
        public string Ubicacion { get; set; }
        public string Sentido { get; set; }
        public string Hora { get; set; }
        public string Marca { get; set; }
        public string Submarca { get; set; }
        public string Color { get; set; }
        public string Placas { get; set; }
        public string Anio { get; set; }
        public string Conductor { get; set; }
        public string Credencial { get; set; }
        public string Descripcion { get; set; }
        public int Lesionados { get; set; }
        public string Nombres { get; set; }
        public string Ambulancia { get; set; }
        public string SeguridaPublica { get; set; }
        public string PatrullaNumero { get; set; }
        public string OficialAcargo { get; set; }
        public string Seguro { get; set; }
        public string Supervisor { get; set; }
        public string Foto_Eco { get; set; }
        public string Foto_Part { get; set; }
        public string Foto_Tarjeton { get; set; }
        public string usuario { get; set; }
    }
}